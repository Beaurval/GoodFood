namespace goodfood_products.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Description { get; set; }
        public byte[] ProductImage { get; set; } = null!;
        public int CategoryId { get; set; }
        public int RestaurantId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
