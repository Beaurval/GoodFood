namespace goodfood_orders.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Description { get; set; } = null!;
        public byte[] ProductImage { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
