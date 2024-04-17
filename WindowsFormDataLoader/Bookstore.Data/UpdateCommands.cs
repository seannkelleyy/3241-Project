using Microsoft.Data.Sqlite;

namespace Bookstore.Data
{
    public class UpdateCommands
    {
        public static void UpdatePerson(int personId, string firstName, string? middleName, string lastName)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "UPDATE Person SET First_Name = @firstName, Middle_Name = @middleName, Last_Name = @lastName WHERE Person_Id = @personId;";
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
            cmd.Parameters.AddWithValue("@personId", personId);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void UpdatePublisher(int publisherId, string name)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "UPDATE Publisher SET Pub_Name = @name WHERE Pub_Id = @publisherId;";
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@publisherId", publisherId);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void UpdateAuthor(int authorId, int personId)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "UPDATE Author SET Auth_Id = @personId WHERE Auth_Id = @authorId;";
            cmd.Parameters.AddWithValue("@personId", personId);
            cmd.Parameters.AddWithValue("@authorId", authorId);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void UpdateBook(string isbn, string title, int publisherId, int year, decimal price, string category)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "UPDATE Book SET Title = @title, Pub_Id = @pubId, Year = @year, Price = @price, Category = @category WHERE ISBN = @isbn;";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@pubId", publisherId);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@category", category);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void UpdateInventory(string isbn, int quantitySold, int storeId)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "UPDATE Stores SET Quantity = Quantity - @quantitySold WHERE ISBN = @isbn AND Store_Id = @storeId;";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@quantitySold", quantitySold);
            cmd.Parameters.AddWithValue("@storeId", storeId);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
    }
}
