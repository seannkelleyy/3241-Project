using Bookstore.Domain;
using Microsoft.Data.Sqlite;

namespace Bookstore.Data
{
    public class SelectCommands
    {
        public static int SelectPersonId(SqliteConnection conn, string firstName, string? middleName, string lastName)
        {
            SqliteCommand cmd = conn.CreateCommand();
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

        public static int SelectPublisherId(SqliteConnection conn, string name)
        {
            SqliteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Pub_Id FROM Publisher WHERE lower(trim(Pub_Name)) = @name";
            cmd.Parameters.AddWithValue("@name", name.ToLower());
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static Publisher SelectPublisher(SqliteConnection conn, int id)
        {
            SqliteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Name FROM Publisher WHERE Pub_Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            return new Publisher()
            {
                Pub_ID = id,
                Pub_Name = (string)cmd.ExecuteScalar()
            };
        }

        public static int SelectAuthorId(SqliteConnection conn, int authId)
        {
            SqliteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Auth_Id FROM Author WHERE Auth_Id = @authId";
            cmd.Parameters.AddWithValue("@authId", authId);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static Book SelectBookId(SqliteConnection conn, string isbn)
        {
            SqliteCommand cmd = conn.CreateCommand();
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

        public static int SelectBookCount(SqliteConnection conn, string isbn)
        {
            SqliteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Book WHERE ISBN = @isbn";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static int SelectWritesId(SqliteConnection conn, string isbn, int authId)
        {
            SqliteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Auth_ID FROM Writes WHERE ISBN = @isbn AND Auth_Id = @authId";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@authId", authId);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}
