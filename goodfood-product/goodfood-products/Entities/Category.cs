namespace goodfood_products.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Product> Products { get; set; } = null!;
    }
}
