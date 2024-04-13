using ExcelDataReader;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Diagnostics;

namespace Bookstore.Data
{
    public class LoadData
    {
        public static void LoadExcelData(string pathToExcelFile, string pathToDatabase)
        {
            using (var stream = File.Open(pathToExcelFile, FileMode.Open, FileAccess.Read))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();
                    DataTable dt = result.Tables[0];

                    using (SqliteConnection conn = new SqliteConnection($"Data Source={pathToDatabase};"))
                    {
                        conn.Open();

                        using (SqliteCommand cmd = conn.CreateCommand())
                        {
                            string? lastISBN = "";
                            cmd.CommandText = "BEGIN TRANSACTION;";
                            cmd.ExecuteNonQuery();

                            for (int row = 2; row < dt.Rows.Count; row++) // Start from index 3 to skip the first two rows that contain headers
                            {
                                DataRow dataRow = dt.Rows[row];
                                Debug.WriteLine($"Processing row {row}...");

                                object? queryResult;

                                string? isbn = dataRow[0]?.ToString()?.PadLeft(10, '0');
                                if (string.IsNullOrEmpty(isbn))
                                {
                                    isbn = lastISBN;
                                }
                                else
                                {
                                    lastISBN = isbn;
                                }

                                string? title = dataRow[1]?.ToString()?.Replace("'", "''");
                                string? publisherName = dataRow[3]?.ToString()?.Replace("'", "''");


                                string?[] authorNameParts = SplitName(dataRow[2]?.ToString());

                                int authId;

                                int personId = SelectCommands.SelectPersonId(conn, authorNameParts[0], authorNameParts[1], authorNameParts[2]);

                                if (personId == -1)
                                {
                                    authId = InsertCommands.InsertPerson(conn, authorNameParts[0], authorNameParts[1], authorNameParts[2]);
                                    InsertCommands.InsertAuthor(conn, authId);
                                }
                                else
                                {
                                    authId = SelectCommands.SelectAuthorId(conn, personId);
                                }

                                queryResult = SelectCommands.SelectPublisherId(conn, publisherName);

                                int pubId;
                                if (queryResult != null)
                                {
                                    pubId = Convert.ToInt32(queryResult);
                                }
                                else
                                {
                                    pubId = InsertCommands.InsertPublisher(conn, publisherName);
                                }

                                int.TryParse(dataRow[4].ToString(), out int year);
                                double.TryParse(dataRow[5]?.ToString()?.Replace("$", ""), out double price);
                                string? category = dataRow[6].ToString();

                                int bookCount = SelectCommands.SelectBookCount(conn, isbn);

                                if (bookCount == 0)
                                {
                                    InsertCommands.InsertBook(conn, isbn, title, pubId, year, (decimal)price, category);
                                }

                                InsertCommands.InsertWrites(conn, isbn, authId);
                            }
                            cmd.CommandText = "COMMIT TRANSACTION;";
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                }
            }
        }

        //private string[] SplitName(string name)
        //{
        //    string?[] authorNameParts = name.Split(' ');
        //    string? firstName = authorNameParts[0].Trim().ToLower();
        //    string? middleName = authorNameParts.Length > 2 ? authorNameParts[1].Trim().ToLower() : null;
        //    string? lastName = authorNameParts.Length == 2 ? authorNameParts[authorNameParts.Length - 1].Trim().ToLower() : null;
        //    return new string[] { firstName, middleName, lastName };
        //}

        //private static string[] SplitName(string name)
        //{
        //    string[] nameParts = name.Split(' ');
        //    string firstName = nameParts[0].Trim().ToLower();
        //    string lastName = nameParts[nameParts.Length - 1].Trim().ToLower();

        //    string middleName = null;
        //    if (nameParts.Length > 2)
        //    {
        //        // Combine all parts between the first and last name as the middle name
        //        middleName = string.Join(" ", nameParts.Skip(1).Take(nameParts.Length - 2)).Trim().ToLower();
        //    }

        //    return new string[] { firstName, middleName, lastName };
        //}

        private static string[] SplitName(string name)
        {
            string[] nameParts = name.Split(' ');
            string firstName, middleName, lastName;

            if (name.Contains(','))
            {
                // If name contains a comma, treat the part before the comma as the last name
                lastName = nameParts[0].Trim().ToLower();
                firstName = nameParts[1].Trim().ToLower();

                if (nameParts.Length > 3)
                {
                    // Combine all parts after the first and second as the middle name
                    middleName = string.Join(" ", nameParts.Skip(2)).Trim().ToLower();
                }
                else
                {
                    middleName = null;
                }
            }
            else
            {
                firstName = nameParts[0].Trim().ToLower();
                lastName = nameParts[nameParts.Length - 1].Trim().ToLower();

                if (nameParts.Length > 2)
                {
                    // Combine all parts between the first and last name as the middle name
                    middleName = string.Join(" ", nameParts.Skip(1).Take(nameParts.Length - 2)).Trim().ToLower();
                }
                else
                {
                    middleName = null;
                }
            }

            return new string[] { firstName, middleName, lastName };
        }


    }
}
