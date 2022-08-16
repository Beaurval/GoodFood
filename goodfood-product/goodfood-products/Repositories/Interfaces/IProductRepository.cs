using goodfood_products.Entities;
using goodfood_products.Models.ProductModels;

namespace goodfood_products.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<ICollection<Product>> GetAllProducts();
        public Task<Product> GetProductById(int id);
        public Task<Product> CreateProduct(CreateProductModel productModel);
        public Task UpdateProduct(UpdateProductModel productModel);
        public void DeleteProduct(int idProduct);
    }
}
