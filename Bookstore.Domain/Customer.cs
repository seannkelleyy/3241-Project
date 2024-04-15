namespace Bookstore.Domain
{
    public class Customer : Person
    {
        public required int Cust_Id { get; set; }
        public required long Phone_No { get; set; }
        public string FullName
        {
            get
            {
                return $"{First_Name} {Last_Name}";
            }
        }
    }
}
