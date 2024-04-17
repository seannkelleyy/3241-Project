using Microsoft.Data.Sqlite;

namespace Bookstore.Data
{
    public class DatabaseConnection
    {
        public static SqliteConnection conn;

        public static void OpenConnection(string pathToDatabase)
        {
            conn = new SqliteConnection($"Data Source={pathToDatabase};");
            conn.Open();
        }

        public static void CloseConnection()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception)
            {
                // Do nothing
            }
        }

        public static void BeginTransaction()
        {
            using (SqliteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "BEGIN TRANSACTION;";
                cmd.ExecuteNonQuery();
            }
        }

        public static void EndTransaction()
        {
            using (SqliteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "END TRANSACTION;";
                cmd.ExecuteNonQuery();
            }
        }
    }
}
