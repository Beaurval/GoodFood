﻿using goodfood_products.Entities;
using goodfood_products.Models.CategoryModels;

namespace goodfood_products.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<ICollection<Category>> GetAllCategories();
        public Task<Category> GetCategoryById(int id);
        public Task<Category> CreateCategory(CreateCategoryModel categoryModel);
        public Task UpdateCategory(UpdateCategoryModel categoryModel);
        public void DeleteCategory(int idCategory);
    }
}
