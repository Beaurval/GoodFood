using goodfood_products.Entities;
using goodfood_products.Models.CategoryModels;
using goodfood_products.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace goodfood_products.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductContext _productContext;

        public CategoryRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<ICollection<Category>> GetAllCategories() => 
            await _productContext.Categories.ToListAsync();

        public async Task<Category> GetCategoryById(int id) 
            => (await _productContext.Categories.FirstOrDefaultAsync(c => c.Id == id))!;

        public async Task<Category> CreateCategory(CreateCategoryModel categoryModel)
        {
            Category category = new() {Name = categoryModel.Name};
            await _productContext.Categories.AddAsync(category);

            return category;
        }

        public async Task UpdateCategory(UpdateCategoryModel categoryModel)
        {
            Category categoryFromDb = await GetCategoryById(categoryModel.Id);
            categoryFromDb.Name = categoryModel.Name;
            _productContext.Categories.Update(categoryFromDb);
        }

        public async void DeleteCategory(int idCategory) 
            => _productContext.Categories.Remove(await GetCategoryById(idCategory));
    }
}
