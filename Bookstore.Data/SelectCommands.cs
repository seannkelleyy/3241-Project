using Bookstore.Domain;
using Microsoft.Data.Sqlite;

namespace Bookstore.Data
{
    public class SelectCommands
    {
        public static int SelectPersonId(string firstName, string? middleName, string lastName)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT Id FROM Person WHERE lower(trim(First_Name)) = @firstName AND lower(trim(Middle_Name)) = @middleName AND lower(trim(Last_Name)) = @lastName";
            cmd.Parameters.AddWithValue("@firstName", firstName.ToLower());
            if (middleName != null)
            {
                cmd.Parameters.AddWithValue("@middleName", middleName.ToLower());
            }
            else
            {
                cmd.Parameters.AddWithValue("@middleName", "");
            }
            cmd.Parameters.AddWithValue("@lastName", lastName.ToLower());
            object? result = cmd.ExecuteScalar();
            if (result == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(result);
            }
        }

        public static Person SelectPerson(int id)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT First_Name, Middle_Name, Last_Name FROM Person WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqliteDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                return null;
            }
            return new Person()
            {
                Id = id,
                First_Name = reader["First_Name"].ToString(),
                Middle_Name = reader["Middle_Name"].ToString(),
                Last_Name = reader["Last_Name"].ToString()
            };
        }

        public static int SelectPublisherId(string name)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT Pub_Id FROM Publisher WHERE lower(trim(Pub_Name)) = @name";
            cmd.Parameters.AddWithValue("@name", name.ToLower());
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static Publisher SelectPublisher(int id)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT Name FROM Publisher WHERE Pub_Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            return new Publisher()
            {
                Pub_ID = id,
                Pub_Name = (string)cmd.ExecuteScalar()
            };
        }

        public static int SelectAuthorId(int authId)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT Auth_Id FROM Author WHERE Auth_Id = @authId";
            cmd.Parameters.AddWithValue("@authId", authId);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static Book SelectBookId(string isbn)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT ISBN, Title, Pub_Id, Year, Price, Category FROM Book WHERE ISBN = @isbn";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            SqliteDataReader reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            return new Book()
            {
                ISBN = reader["ISBN"].ToString(),
                Title = reader["Title"].ToString(),
                PublisherId = Convert.ToInt32(reader["Pub_Id"]),
                Year = Convert.ToInt32(reader["Year"]),
                Price = Convert.ToDecimal(reader["Price"]),
                Category = reader["Category"].ToString()
            };
        }

        public static int SelectBookCount(string isbn)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Book WHERE ISBN = @isbn";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static int SelectWritesId(string isbn, int authId)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT Auth_ID FROM Writes WHERE ISBN = @isbn AND Auth_Id = @authId";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@authId", authId);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static int SelectCustomerId(string phoneNumber)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT Cust_Id FROM Customer WHERE Phone_No = @phoneNumber";
            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            object? result = cmd.ExecuteScalar();
            if (result == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(result);
            }
        }

        public static List<Customer> SelectCustomers()
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM CUSTOMER WHERE Cust_Id > 0;";
            cmd.ExecuteScalar();
            SqliteDataReader reader = cmd.ExecuteReader();
            List<Customer> customers = new List<Customer>();
            while (reader.Read())
            {
                Person person = SelectPerson(Convert.ToInt32(reader["Cust_Id"]));
                customers.Add(new Customer()
                {
                    Id = person.Id,
                    Cust_Id = Convert.ToInt32(reader["Cust_Id"]),
                    Phone_No = Convert.ToInt64(reader["Phone_No"]),
                    First_Name = person.First_Name,
                    Middle_Name = person.Middle_Name,
                    Last_Name = person.Last_Name
                });
            }
            return customers;
        }
    }
}
