using Microsoft.Data.Sqlite;

namespace Bookstore.Data
{
    public class InsertCommands
    {
        public static int InsertPerson(SqliteConnection conn, string firstName, string? middleName, string lastName)
        {
            SqliteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Person (First_Name, Middle_Name, Last_Name) VALUES (@firstName, @middleName, @lastName);";
            cmd.Parameters.AddWithValue("@firstName", firstName);
            if (middleName != null)
            {
                cmd.Parameters.AddWithValue("@middleName", middleName);
            }
            else
            {
                cmd.Parameters.AddWithValue("@middleName", "");
            }
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return SelectCommands.SelectPersonId(conn, firstName, middleName, lastName);
        }
        public static int InsertPublisher(SqliteConnection conn, string name)
        {
            SqliteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Publisher (Name) VALUES (@name);";
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return SelectCommands.SelectPublisherId(conn, name);
        }

        public static int InsertAuthor(SqliteConnection conn, int personId)
        {
            SqliteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Author (Auth_Id) VALUES (@authId);";
            cmd.Parameters.AddWithValue("@authId", personId);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return SelectCommands.SelectAuthorId(conn, personId);
        }

        public static string InsertBook(SqliteConnection conn, string isbn, string title, int publisherId, int year, decimal price, string category)
        {
            SqliteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Book (ISBN, Title, Pub_Id, Year, Price, Category) VALUES (@isbn, @title, @pubId, @year, @price, @category);";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@pubId", publisherId);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@category", category);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return isbn;
        }

        public static void InsertWrites(SqliteConnection conn, string isbn, int authorId)
        {
            SqliteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Writes (ISBN, Auth_ID) VALUES (@isbn, @authId);";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@authId", authorId);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
    }
}
