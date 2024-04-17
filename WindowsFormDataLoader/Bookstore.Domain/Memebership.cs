namespace Bookstore.Domain
{
    public class Memebership
    {
        public required int Mem_Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required Customer Customer { get; set; }
    }
}
