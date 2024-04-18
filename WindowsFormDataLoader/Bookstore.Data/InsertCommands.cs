using Microsoft.Data.Sqlite;
using System.Diagnostics;

namespace Bookstore.Data
{
    public class InsertCommands
    {
        public static int InsertPerson(string firstName, string? middleName, string lastName)
        {
            if (SelectCommands.SelectPersonId(firstName, middleName, lastName) != -1)
            {
                return SelectCommands.SelectPersonId(firstName, middleName, lastName);
            }
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
            if (SelectCommands.SelectPublisherId(name) != -1)
            {
                return SelectCommands.SelectPublisherId(name);
            }
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Publisher (Pub_Name) VALUES (@name);";
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return SelectCommands.SelectPublisherId(name);
        }

        public static int InsertAuthor(int personId)
        {
            if (SelectCommands.SelectAuthorId(personId) != -1)
            {
                return SelectCommands.SelectAuthorId(personId);
            }
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Author (Auth_Id) VALUES (@personId);";
            cmd.Parameters.AddWithValue("@personId", personId);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return SelectCommands.SelectAuthorId(personId);
        }

        public static string InsertBook(string isbn, string title, int publisherId, int year, decimal price)
        {
            if (SelectCommands.SelectBookById(isbn) != null)
            {
                return isbn;
            }
            if (isbn == "0000000000")
            {
                return "-1";
            }
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Book (ISBN, Title, Pub_Id, Year, Price) VALUES (@isbn, @title, @pubId, @year, @price);";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@pubId", publisherId);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return isbn;
        }

        public static void InsertBookPurchase(string isbn, int quantity, int orderNumber)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Order_Books (ISBN, Quantity, Order_No) VALUES (@isbn, @quantity, @orderNumber);";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void InsertWrites(string isbn, int authorId)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Writes (ISBN, Auth_ID) VALUES (@isbn, @authId);";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@authId", authorId);
            Debug.WriteLine("Inserting Writes: " + isbn + " " + authorId);
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
            cmd.CommandText = "INSERT INTO Customer (Cust_Id, Phone_No) VALUES (@personId, @phone);";
            cmd.Parameters.AddWithValue("@personId", personId);
            cmd.Parameters.AddWithValue("@phone", phoneNumber);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return SelectCommands.SelectCustomerByPhone(phoneNumber);
        }

        public static void InsertPurchase(int customerId, string isbn, int quantity, int storeNumber, decimal price)
        {
            if (SelectCommands.SelectPurchaseId(customerId, storeNumber, price) != -1)
            {
                return;
            }
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Purchase (Cust_Id, Store_No, Price, Date) VALUES (@custId, @storeNumber, @price, @date);";
            cmd.Parameters.AddWithValue("@custId", customerId);
            cmd.Parameters.AddWithValue("@storeNumber", storeNumber);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            InsertPurchaseBook(isbn, quantity, SelectCommands.SelectPurchaseId(customerId, storeNumber, price));
        }

        public static void InsertBookstore(string storeLocation)
        {
            if (SelectCommands.SelectBookstoreId(storeLocation) != -1)
            {
                return;
            }
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Bookstore (Store_Loc) VALUES (@storeLoc);";
            cmd.Parameters.AddWithValue("@storeLoc", storeLocation);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void InsertMembership(int customerId, string email, string password)
        {
            if (SelectCommands.SelectMembershipId(customerId) != -1)
            {
                return;
            }
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Membership (Mem_Id, Email, Password) VALUES (@memberId, @email, @password);";
            cmd.Parameters.AddWithValue("@memberId", customerId);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void InsertStores(string isbn, int storeNumber, int quantity)
        {
            if (SelectCommands.SelectInventory(storeNumber, isbn) != -1)
            {
                return;
            }
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Stores (ISBN, Store_Id, Quantity) VALUES (@isbn, @storeNumber, @quantity);";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@storeNumber", storeNumber);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void InsertPurchaseBook(string isbn, int quantity, int orderNumber)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Order_Books (ISBN, Quantity, Order_No) VALUES (@isbn, @quantity, @orderNumber);";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static void InsertCategory(string isbn, string category)
        {
            if (SelectCommands.SelectCategoryCount(isbn, category) > 0)
            {
                return;
            }
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Categories (ISBN, Category) VALUES (@isbn, @category);";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@category", category);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }


        // Inserts 20 entries into each table
        public static void InsertTestData()
        {
            string[] firstNames = { "John", "Jane", "James", "Jill", "Jack", "Jenny", "Jared", "Jasmine", "Jasper", "Jocelyn", "Jude", "Jenna", "Jesse", "Jill", "Jacob", "Julia", "Jodie", "Jeremy", "Janet", "Justin" };
            string[] lastNames = { "Smith", "Doe", "Johnson", "Brown", "White", "Black", "Green", "Blue", "Red", "Orange", "Purple", "Yellow", "Gray", "Pink", "Cyan", "Magenta", "Lavender", "Maroon", "Teal", "Robinson" };
            string[] middleNames = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T" };
            string[] storeLocations = { "123 Main St", "456 Elm St", "789 Oak St", "1011 Pine St", "1213 Maple St", "1415 Cedar St", "1617 Walnut St", "1819 Birch St", "2021 Spruce St", "2223 Ash St", "2425 Willow St", "2627 Cherry St", "2829 Chestnut St", "3031 Beech St", "3233 Alder St", "3435 Holly St", "3637 Hazel St", "3839 Aspen St", "4041 Larch St", "4243 Poplar St", "250 S High St", "2015 Neil Ave", "2069 Neil Ave", "2020 Neil Ave" };
            string[] phoneNumbers = { "5555555555", "5555555556", "5555555557", "5555555558", "5555555559", "5555555560", "5555555561", "5555555562", "5555555563", "5555555564", "5555555565", "5555555566", "5555555567", "5555555568", "5555555569", "5555555570", "5555555571", "5555555572", "5555555573", "5555555574" };
            Random rand = new Random();
            for (int i = 0; i < 40; i++)
            {
                int randomIndex1 = rand.Next(firstNames.Length);
                int randomIndex2 = rand.Next(middleNames.Length);
                int randomIndex3 = rand.Next(lastNames.Length);
                int randomIndex4 = rand.Next(storeLocations.Length);
                int randomIndex5 = rand.Next(phoneNumbers.Length);

                InsertPerson(firstNames[randomIndex1], middleNames[randomIndex2], lastNames[randomIndex3]);
                int custId = InsertCustomer(firstNames[randomIndex1], middleNames[randomIndex2 % 10], lastNames[randomIndex3], phoneNumbers[randomIndex5]);
                InsertBookstore(storeLocations[randomIndex4]);
                InsertMembership(custId, $"email{i}@example.com", $"password{i}");
                InsertStores(SelectCommands.SelectRandomBook(), SelectCommands.SelectBookstoreId(storeLocations[randomIndex4]), i + rand.Next(50, 100));
                InsertPurchase(SelectCommands.SelectRandomCustomerId(), SelectCommands.SelectRandomBook(), i + rand.Next(0, 50), SelectCommands.SelectBookstoreId(storeLocations[randomIndex4]), 10.00m);
            }
        }
    }
}
