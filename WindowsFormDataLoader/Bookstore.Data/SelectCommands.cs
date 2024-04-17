using Bookstore.Domain;
using Microsoft.Data.Sqlite;

namespace Bookstore.Data
{
    public class SelectCommands
    {
        // Person
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
            return Convert.ToInt32(result);
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

        public static List<Person> SelectAllPeople()
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Person WHERE Id > 0;";
            cmd.ExecuteScalar();
            SqliteDataReader reader = cmd.ExecuteReader();
            List<Person> people = new List<Person>();
            while (reader.Read())
            {
                people.Add(new Person()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    First_Name = reader["First_Name"].ToString(),
                    Middle_Name = reader["Middle_Name"].ToString(),
                    Last_Name = reader["Last_Name"].ToString()
                });
            }
            return people;
        }

        // Publisher

        public static int SelectPublisherId(string name)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT Pub_Id FROM Publisher WHERE lower(trim(Pub_Name)) = @name";
            cmd.Parameters.AddWithValue("@name", name.ToLower());
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            if (id == 0)
            {
                return -1;
            }
            return id;
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

        // Author

        public static int SelectAuthorId(int authId)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT Auth_Id FROM Author WHERE Auth_Id = @authId";
            cmd.Parameters.AddWithValue("@authId", authId);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            if (id == 0)
            {
                return -1;
            }
            return id;
        }


        // Books
        public static Book SelectBookById(string isbn)
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

        public static decimal SelectBookPrice(string isbn)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT Price FROM Book WHERE ISBN = @isbn";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            decimal price = Convert.ToDecimal(cmd.ExecuteScalar());
            if (price == 0)
            {
                return -1;
            }
            return price;
        }

        public static int SelectBookCount(string isbn)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Book WHERE ISBN = @isbn";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count;
        }

        public static List<Book> SelectBooks()
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Book WHERE ISBN > 0;";
            cmd.ExecuteScalar();
            SqliteDataReader reader = cmd.ExecuteReader();
            List<Book> books = new List<Book>();
            while (reader.Read())
            {
                books.Add(new Book()
                {
                    ISBN = reader["ISBN"].ToString(),
                    Title = reader["Title"].ToString(),
                    PublisherId = Convert.ToInt32(reader["Pub_Id"]),
                    Year = Convert.ToInt32(reader["Year"]),
                    Price = Convert.ToDecimal(reader["Price"]),
                    Category = reader["Category"].ToString()
                });
            }
            return books;
        }

        public static string SelectRandomBook()
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT ISBN FROM Book ORDER BY RANDOM() LIMIT 1;";
            if (cmd.ExecuteScalar() == null)
            {
                return null;
            }
            return cmd.ExecuteScalar().ToString();
        }

        // Writes

        public static int SelectWritesId(string isbn, int authId)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT Auth_ID FROM Writes WHERE ISBN = @isbn AND Auth_Id = @authId";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@authId", authId);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            if (id == 0)
            {
                return -1;
            }
            return id;
        }


        // Customer
        public static int SelectCustomerByPhone(string phoneNumber)
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

        public static int SelectCustomerById(int id)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT Cust_Id FROM Customer WHERE Cust_Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
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

        public static int SelectRandomCustomerId()
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT Cust_Id FROM Customer ORDER BY RANDOM() LIMIT 1;";
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            if (id == 0)
            {
                return -1;
            }
            return id;
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
                    Last_Name = person.Last_Name,
                });
            }
            return customers;
        }

        // Membership
        public static int SelectMembershipId(int custId)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT Mem_Id FROM Membership WHERE Mem_Id = @custId";
            cmd.Parameters.AddWithValue("@custId", custId);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            if (id == 0)
            {
                return -1;
            }
            return id;
        }

        // Bookstore
        public static List<Store> SelectBookstores()
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Bookstore WHERE Store_Id > 0;";
            cmd.ExecuteScalar();
            SqliteDataReader reader = cmd.ExecuteReader();
            List<Store> bookstores = new List<Store>();
            while (reader.Read())
            {
                bookstores.Add(new Store()
                {
                    Store_No = Convert.ToInt32(reader["Store_Id"]),
                    Store_Loc = reader["Store_Loc"].ToString()
                });
            }
            return bookstores;
        }

        public static int SelectBookstoreId(string storeLoc)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT Store_Id FROM Bookstore WHERE lower(trim(Store_Loc)) = @storeLoc";
            cmd.Parameters.AddWithValue("@storeLoc", storeLoc.ToLower());
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            if (id == 0)
            {
                return -1;
            }
            return id;
        }

        public static int SelectInventory(int storeNum, string isbn)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT Quantity FROM Stores WHERE ISBN = @isbn AND Store_Id = @storeNum";
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@storeNum", storeNum);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 0)
            {
                return -1;
            }
            return count;
        }

        // Purchase
        public static int SelectPurchaseId(int custId, int storeNumber, decimal price)
        {
            SqliteCommand cmd = DatabaseConnection.conn.CreateCommand();
            cmd.CommandText = "SELECT Order_No FROM Purchase WHERE Cust_Id = @custId AND Store_No = @storeNumber AND Price = @price";
            cmd.Parameters.AddWithValue("@custId", custId);
            cmd.Parameters.AddWithValue("@storeNumber", storeNumber);
            cmd.Parameters.AddWithValue("@price", price);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            if (id == 0)
            {
                return -1;
            }
            return id;
        }
    }
}
