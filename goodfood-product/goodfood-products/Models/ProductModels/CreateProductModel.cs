namespace goodfood_products.Models.ProductModels
{
    public class CreateProductModel
    {
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Description { get; set; }
        public IFormFile ImageToUpload { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
