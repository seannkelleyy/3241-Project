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
                    var result = reader.AsDataSet();
                    DataTable dt = result.Tables[0];

                    using (SqliteConnection conn = new SqliteConnection("Data Source=C:\\development\\cse\\3241-Project\\3241-Project.db;"))
                    {
                        conn.Open();

                        using (SqliteCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "BEGIN TRANSACTION;";
                            cmd.ExecuteNonQuery();
                            // Insert Data from Excel to SQLite
                            for (int row = 2; row < dt.Rows.Count; row++) // Start from index 3 to skip the first two rows
                            {
                                DataRow dataRow = dt.Rows[row];
                                string isbn = dataRow[0].ToString();
                                Debug.WriteLine(isbn);
                                string title = dataRow[1].ToString().Replace("'", "''");
                                Debug.WriteLine(title);
                                string authorFullName = dataRow[2].ToString();
                                Debug.WriteLine(authorFullName);
                                string publisherName = dataRow[3].ToString().Replace("'", "''");
                                Debug.WriteLine(publisherName);

                                // Split the author's full name into first, middle, and last name
                                string[] authorNameParts = authorFullName.Split(' ');
                                string firstName = authorNameParts[0];
                                string middleName = authorNameParts.Length > 2 ? authorNameParts[1] : null;
                                string lastName = authorNameParts.Length > 1 ? authorNameParts[authorNameParts.Length - 1] : null;

                                object queryResult; // Declare result here
                                int authId;

                                // Check if person already exists
                                // Check if person already exists
                                cmd.CommandText = "SELECT ID FROM Person WHERE First_Name = @firstName AND Middle_Name = @middleName AND Last_Name = @lastName";
                                cmd.Parameters.AddWithValue("@firstName", firstName ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@middleName", middleName ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@lastName", lastName ?? (object)DBNull.Value);
                                queryResult = cmd.ExecuteScalar(); // Assign to result here
                                cmd.Parameters.Clear();
                                if (queryResult != null && int.TryParse(queryResult.ToString(), out authId))
                                {
                                    // If person exists, use the existing ID
                                }
                                else
                                {
                                    // If person does not exist, insert it and get the new ID
                                    cmd.CommandText = "INSERT INTO Person(First_Name, Middle_Name, Last_Name) VALUES (@firstName, @middleName, @lastName); SELECT last_insert_rowid();";
                                    cmd.Parameters.AddWithValue("@firstName", firstName ?? (object)DBNull.Value);
                                    cmd.Parameters.AddWithValue("@middleName", middleName ?? (object)DBNull.Value);
                                    cmd.Parameters.AddWithValue("@lastName", lastName ?? (object)DBNull.Value);
                                    queryResult = cmd.ExecuteScalar(); // Assign to result here
                                    cmd.Parameters.Clear();
                                    authId = Convert.ToInt32(queryResult);

                                    // Insert a new author that relates to the person
                                    cmd.CommandText = "INSERT INTO Author(Auth_ID) VALUES (@personId)";
                                    cmd.Parameters.AddWithValue("@personId", authId);
                                    cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();
                                }


                                // Check if publisher already exists
                                cmd.CommandText = $"SELECT Pub_ID FROM Publisher WHERE pub_name = '{publisherName}'";
                                queryResult = cmd.ExecuteScalar();
                                int pubId;
                                if (queryResult != null)
                                {
                                    pubId = Convert.ToInt32(queryResult);
                                }
                                else
                                {
                                    // If publisher does not exist, insert it and get the new Pub_ID
                                    cmd.CommandText = $"INSERT INTO Publisher(pub_name) VALUES ('{publisherName}'); SELECT last_insert_rowid();";
                                    pubId = Convert.ToInt32(cmd.ExecuteScalar());
                                }

                                // Use int.TryParse to avoid FormatException
                                if (int.TryParse(dataRow[4].ToString(), out int year))
                                {
                                    Debug.WriteLine(year);
                                }
                                else
                                {
                                    Debug.WriteLine("Year is not a valid integer");
                                    continue; // Skip this row if year is not a valid integer
                                }

                                if (double.TryParse(dataRow[5].ToString().Replace("$", ""), out double price))
                                {
                                    Debug.WriteLine(price);
                                }
                                else
                                {
                                    Debug.WriteLine("Price is not a valid double");
                                    continue; // Skip this row if price is not a valid double
                                }

                                string? category = dataRow[6].ToString();
                                Debug.WriteLine(category);

                                // Check if book already exists
                                cmd.CommandText = $"SELECT COUNT(*) FROM Book WHERE ISBN = '{isbn}'";
                                int bookCount = Convert.ToInt32(cmd.ExecuteScalar());

                                // If book does not exist, insert it
                                if (bookCount == 0)
                                {
                                    cmd.CommandText =
                                        $"INSERT INTO Book(ISBN ,Title ,Auth_id, Pub_Id ,Year ,Price ,Category) VALUES ('{isbn}', '{title}', '{authId}', '{pubId}', {year}, {price},'{category}')";
                                    cmd.ExecuteNonQuery();
                                }

                                // Similar checks can be added for authors and publishers
                            }
                            cmd.CommandText = "COMMIT TRANSACTION;";
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                }
            }

            Debug.WriteLine("Data imported successfully!");
        }
    }
}
