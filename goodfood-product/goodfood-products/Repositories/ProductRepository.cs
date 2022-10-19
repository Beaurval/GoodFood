using goodfood_products.Entities;
using goodfood_products.Models.ProductModels;
using goodfood_products.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace goodfood_products.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<ICollection<Product>> GetAllProducts() 
            => await _productContext.Products.Include("Category").ToListAsync();

        public async Task<Product> GetProductById(int id) 
            => (await _productContext.Products.Include("Category").FirstOrDefaultAsync(p => p.Id == id))!;

        public async Task<Product> CreateProduct(CreateProductModel productModel)
        {
            byte[] convertedImage = null!;
            if (productModel.ImageToUpload.Length > 0)
            {
                using var ms = new MemoryStream();
                await productModel.ImageToUpload.CopyToAsync(ms);
                convertedImage = ms.ToArray();
            }

            Product product = new()
            { 
                CategoryId = productModel.CategoryId,
                Name = productModel.Name,
                Description = productModel.Description,
                ProductImage = convertedImage,
                Price = productModel.Price,
                RestaurantId = productModel.RestaurantId
            };

            await _productContext.Products.AddAsync(product);
            return product;
        }

        public async Task UpdateProduct(UpdateProductModel productModel)
        {
            Product product = await GetProductById(productModel.Id);
            product.CategoryId = productModel.CategoryId;
            product.Name = productModel.Name;
            product.Description = productModel.Description;
            product.Price = productModel.Price;

            if (productModel.ImageToUpload.Length > 0)
            {
                using var ms = new MemoryStream();
                await productModel.ImageToUpload.CopyToAsync(ms);
                product.ProductImage = ms.ToArray();
            }

            _productContext.Products.Update(product);
        }

        public async void DeleteProduct(int idProduct)
        {
            Product product = await GetProductById(idProduct);
            _productContext.Remove(product);
        }
    }
}
