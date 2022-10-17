using goodfood_products.Entities;
using goodfood_products.Models.CategoryModels;
using goodfood_products.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace goodfood_products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(ICategoryService categoryService, IUnitOfWork unitOfWork)
        {
            _categoryService = categoryService; 
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Category>>> GetCategories()
        {
            return (await _categoryService.GetAllCategoriesAsync()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            return await _categoryService.GetCategoryByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory([FromForm] CreateCategoryModel categoryModel)
        {
            Category category = await _categoryService.CreateCategoryAsync(categoryModel);
            await _unitOfWork.SaveChangesAsync();
            return category;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(int id,[FromForm] UpdateCategoryModel categoryModel)
        {
            if (id != categoryModel.Id)
            {
                return BadRequest();
            }

            await _categoryService.UpdateCategoryAsync(categoryModel);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            _categoryService.DeleteCategoryAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
