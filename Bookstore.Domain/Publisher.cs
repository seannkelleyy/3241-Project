namespace Bookstore.Domain
{
    public class Publisher
    {
        public required int Pub_ID { get; set; }
        public required string Pub_Name { get; set; }
        public required Book[] Books { get; set; }
    }
}
