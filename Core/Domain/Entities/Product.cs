namespace Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        // Navigation
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
