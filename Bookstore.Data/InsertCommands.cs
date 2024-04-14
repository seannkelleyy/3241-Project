using Microsoft.Data.Sqlite;

namespace Bookstore.Data
{
    public class InsertCommands
    {
        public static int InsertPerson(string firstName, string? middleName, string lastName)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
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
            return SelectCommands.SelectPersonId(firstName, middleName, lastName);
        }
        public static int InsertPublisher(string name)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Publisher (Name) VALUES (@name);";
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return SelectCommands.SelectPublisherId(name);
        }

        public static int InsertAuthor(int personId)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Author (Auth_Id) VALUES (@authId);";
            cmd.Parameters.AddWithValue("@authId", personId);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return SelectCommands.SelectAuthorId(personId);
        }

        public static string InsertBook(string isbn, string title, int publisherId, int year, decimal price, string category)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
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

        public static void InsertWrites(string isbn, int authorId)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Writes (ISBN, Auth_ID) VALUES (@isbn, @authId);";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@authId", authorId);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static int InsertCustomer(string firstName, string? middleName, string lastName, string phoneNumber)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            int personId = SelectCommands.SelectPersonId(firstName, middleName, lastName);
            if (personId != -1)
            {
                return personId;
            }
            personId = InsertPerson(firstName, middleName, lastName);
            cmd.CommandText = "INSERT INTO Customer (Cust_Id, Phone_No) VALUES (@custId, @phone);";
            cmd.Parameters.AddWithValue("@custId", personId);
            cmd.Parameters.AddWithValue("@phone", phoneNumber);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return SelectCommands.SelectCustomerId(phoneNumber);
        }

        public static void InsertPurchase(int customerId, string isbn, int quantity, int storeNumber, decimal price)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Purchase (Cust_Id, Book, Quantity, Store_No, Price, Date) VALUES (@custId, @isbn, @quantity, @storeNumber, @price, @date);";
            cmd.Parameters.AddWithValue("@custId", customerId);
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@storeNumber", storeNumber);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void InsertBookstore(string storeLocation)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Bookstore (Store_Loc) VALUES (@storeLoc);";
            cmd.Parameters.AddWithValue("@storeLoc", storeLocation);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void InsertMembership(int customerId, string email, string password)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Membership (Mem_Id, Email, Password) VALUES (@memberId, @email, @password);";
            cmd.Parameters.AddWithValue("@memberId", customerId);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void InsertInventory(string isbn, int storeNumber, int quantity)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Inventory (ISBN, Store_Id, Quantity) VALUES (@isbn, @storeNumber, @quantity);";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@storeNumber", storeNumber);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
    }
}
