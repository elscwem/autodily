namespace E_shopAutodily.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Status { get; set; } = "New";

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
