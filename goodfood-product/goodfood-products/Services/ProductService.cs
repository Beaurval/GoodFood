using goodfood_products.Entities;
using goodfood_products.Models.ProductModels;
using goodfood_products.Repositories.Interfaces;
using goodfood_products.Services.Interfaces;

namespace goodfood_products.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ICollection<Product>> GetAllProductsAsync() 
            => await _productRepository.GetAllProducts();

        public async Task<Product> GetProductByIdAsync(int id) 
            => await _productRepository.GetProductById(id);

        public async Task<Product> CreateProductAsync(CreateProductModel productModel) 
            => await _productRepository.CreateProduct(productModel);

        public async Task UpdateProductAsync(UpdateProductModel productModel)
        {
            await _productRepository.UpdateProduct(productModel);
        }

        public void DeleteProductAsync(int id)
        {
            _productRepository.DeleteProduct(id);
        }
    }
}
