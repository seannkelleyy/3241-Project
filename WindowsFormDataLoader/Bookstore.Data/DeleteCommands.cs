using Microsoft.Data.Sqlite;

namespace Bookstore.Data
{
    public class DeleteCommands
    {
        public static void DeleteAllData()
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "delete from writes; delete from order_books; delete from Purchase; delete from Author; delete from Membership; delete from Customer; delete from Person; delete from publisher; delete from stores; delete from Bookstore; delete from categories; delete from book;";
            cmd.ExecuteNonQuery();
        }
        public static void DeleteBook(string isbn)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Book WHERE ISBN = @isbn;";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void DeletePublisher(string name)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Publisher WHERE lower(trim(Pub_Name)) = @name;";
            cmd.Parameters.AddWithValue("@name", name.ToLower());
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void DeletePerson(string firstName, string? middleName, string lastName)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Person WHERE lower(trim(First_Name)) = @firstName AND lower(trim(Middle_Name)) = @middleName AND lower(trim(Last_Name)) = @lastName;";
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
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void DeletePersonId(int personId)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Person WHERE Id = @personId;";
            cmd.Parameters.AddWithValue("@personId", personId);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void DeleteAuthor(int personId)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Author WHERE Auth_Id = @authId;";
            cmd.Parameters.AddWithValue("@authId", personId);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void DeleteWrites(string isbn, int authorId)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Writes WHERE ISBN = @isbn AND Auth_Id = @authId;";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@authId", authorId);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
    }
}
