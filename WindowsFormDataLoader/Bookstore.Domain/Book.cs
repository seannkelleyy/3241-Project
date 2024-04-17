namespace Bookstore.Domain
{
    public class Book
    {
        public required string Title { get; set; }
        public required string ISBN { get; set; }
        public required decimal Price { get; set; }
        public required int Year { get; set; }
        public required int PublisherId { get; set; }
    }
}
