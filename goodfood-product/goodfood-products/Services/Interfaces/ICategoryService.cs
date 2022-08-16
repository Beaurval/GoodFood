using goodfood_products.Entities;
using goodfood_products.Models.CategoryModels;

namespace goodfood_products.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<ICollection<Category>> GetAllCategoriesAsync();
        public Task<Category> GetCategoryByIdAsync(int id);
        public Task<Category> CreateCategoryAsync(CreateCategoryModel categoryModel);
        public Task UpdateCategoryAsync(UpdateCategoryModel categoryModel);
        public void DeleteCategoryAsync(int id);

    }
}
