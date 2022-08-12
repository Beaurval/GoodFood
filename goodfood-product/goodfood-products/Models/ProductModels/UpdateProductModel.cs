namespace goodfood_products.Models.ProductModels
{
    public class UpdateProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public IFormFile ImageToUpload { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
