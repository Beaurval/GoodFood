using goodfood_products.Entities;
using goodfood_products.Models.ProductModels;

namespace goodfood_products.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ICollection<Product>> GetAllProductsAsync();
        public Task<ICollection<Product>> GetAllProductsForRestaurant(int idRestaurant);
        public Task<Product> GetProductByIdAsync(int id);
        public Task<Product> CreateProductAsync(CreateProductModel productModel);
        public Task UpdateProductAsync(UpdateProductModel productModel);
        public void DeleteProductAsync(int id);
    }
}
