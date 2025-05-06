namespace Domain.Entities
{
    public class Order : BaseEntity<int>
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Navigational Property
        public List<Product> Products { get; set; }
    }
}
