namespace Bookstore.Domain
{
    public class Purchase
    {
        public required int Order_No { get; set; }
        public required decimal Total_Price { get; set; }
        public required int Quantity { get; set; }
        public required Book Book { get; set; }
        public DateTime Purchase_Date { get; set; }
        public required Customer Customer { get; set; }
        public required Bookstore Store { get; set; }
    }
}
