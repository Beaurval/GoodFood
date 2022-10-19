using goodfood_products.Entities;
using goodfood_products.Models.ProductModels;
using goodfood_products.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace goodfood_products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;

        public ProductsController(IUnitOfWork unitOfWork, IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Product>>> GetProducts() 
            => (await _productService.GetAllProductsAsync()).ToList();

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            Product product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        [Route("provider/{idRestaurant}")]
        [HttpGet]
        public async Task<ActionResult<ICollection<Product>>> GetProductForRestaurant(int idRestaurant)
        {
            ICollection<Product> products = await _productService.GetAllProductsForRestaurant(idRestaurant);

            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromForm] CreateProductModel productModel)
        {
            Product productFromDatabase = await _productService.CreateProductAsync(productModel);
            await _unitOfWork.SaveChangesAsync();
            return productFromDatabase;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromForm] UpdateProductModel productModel)
        {
            if (id != productModel.Id)
            {
                return BadRequest();
            }

            await _productService.UpdateProductAsync(productModel);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            _productService.DeleteProductAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}
