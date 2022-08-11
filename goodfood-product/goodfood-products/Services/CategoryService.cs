using goodfood_products.Entities;
using goodfood_products.Models.CategoryModels;
using goodfood_products.Repositories.Interfaces;
using goodfood_products.Services.Interfaces;

namespace goodfood_products.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ICollection<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetCategories();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetCategory(id);
        }

        public async Task<Category> CreateCategoryAsync(CreateCategoryModel categoryModel)
        {
            Category category = await _categoryRepository.CreateCategory(categoryModel);
            return category;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryModel categoryModel)
        {
            await _categoryRepository.UpdateCategory(categoryModel);
        }

        public void DeleteCategoryAsync(int id)
        {
            _categoryRepository.DeleteCategory(id);
        }
    }
}
