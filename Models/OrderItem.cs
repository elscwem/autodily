namespace E_shopAutodily.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public string PartName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
