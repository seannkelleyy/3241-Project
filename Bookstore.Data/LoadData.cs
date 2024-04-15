using Bookstore.Domain;
using ExcelDataReader;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Diagnostics;

namespace Bookstore.Data
{
    public class LoadData
    {
        public static void LoadExcelData(string pathToExcelFile)
        {
            using (var stream = File.Open(pathToExcelFile, FileMode.Open, FileAccess.Read))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    SqliteConnection conn = DatabaseConnection.conn;

                    var result = reader.AsDataSet();
                    DataTable dt = result.Tables[0];


                    using (SqliteCommand cmd = conn.CreateCommand())
                    {
                        string? lastISBN = "";
                        DatabaseConnection.BeginTransaction();

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

                            int personId = SelectCommands.SelectPersonId(authorNameParts[0], authorNameParts[1], authorNameParts[2]);

                            if (personId == -1)
                            {
                                authId = InsertCommands.InsertPerson(authorNameParts[0], authorNameParts[1], authorNameParts[2]);
                                InsertCommands.InsertAuthor(authId);
                            }
                            else
                            {
                                authId = SelectCommands.SelectAuthorId(personId);
                            }

                            queryResult = SelectCommands.SelectPublisherId(publisherName);

                            int pubId;
                            if (queryResult != null)
                            {
                                pubId = Convert.ToInt32(queryResult);
                            }
                            else
                            {
                                pubId = InsertCommands.InsertPublisher(publisherName);
                            }

                            int.TryParse(dataRow[4].ToString(), out int year);
                            double.TryParse(dataRow[5]?.ToString()?.Replace("$", ""), out double price);
                            string? category = dataRow[6].ToString();

                            int bookCount = SelectCommands.SelectBookCount(isbn);

                            if (bookCount == 0)
                            {
                                InsertCommands.InsertBook(isbn, title, pubId, year, (decimal)price, category);
                            }

                            InsertCommands.InsertWrites(isbn, authId);
                        }
                        DatabaseConnection.EndTransaction();
                    }
                }
            }
        }

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

            // Check if the last name is actually a suffix (e.g., Jr., Sr., III, etc.)
            string[] suffixes = { "jr", "sr", "ii", "iii", "iv", "v" };
            if (suffixes.Contains(lastName))
            {
                // If the last name is a suffix, shift the names
                lastName = middleName;
                middleName = firstName;
                firstName = null;
            }

            // Check for duplicates
            if (firstName == lastName)
            {
                lastName = null;
            }

            // Check if the middle name is actually a last name
            if (middleName != null && lastName == null)
            {
                lastName = middleName;
                middleName = null;
            }

            return new string[] { firstName, middleName, lastName };
        }

        public static void CleanUpNames()
        {
            List<Person> people = SelectCommands.SelectAllPeople();

            foreach (var person in people)
            {
                // If the last name is null and the middle name is not, move the middle name to the last name
                if (person.Last_Name == null && person.Middle_Name != null)
                {
                    var updateCmd = DatabaseConnection.conn.CreateCommand();
                    updateCmd.CommandText = $"UPDATE Person SET Middle_Name = NULL, Last_Name = '{person.Middle_Name}' WHERE Id = {person.Id}";
                    updateCmd.ExecuteNonQuery();
                }

                // If there's another person with the same first name and this person's middle name as the last name, delete this person
                if (people.Any(p => p.First_Name == person.First_Name && p.Last_Name == person.Middle_Name))
                {
                    DeleteCommands.DeleteAuthor(person.Id);
                    DeleteCommands.DeletePersonId(person.Id);
                }
            }
        }

    }
}
