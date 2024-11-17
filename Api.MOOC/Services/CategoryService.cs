using Api.MOOC.IServices;
using Api.MOOC.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.MOOC.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly MoocDbContext _moocDBContext;
        public CategoryService(MoocDbContext moocDBContext)
        {
            this._moocDBContext = moocDBContext;
        }

        public Category Add(Category category)
        {
            this._moocDBContext.Categories.Add(category);
            this._moocDBContext.SaveChanges();
            return category;
        }

        public List<Category> GetCategories()
        {
            var categories = this._moocDBContext.Categories.ToList();
            return categories;
        }

        public Category? GetCategoryByName(string name)
        {
            return this._moocDBContext.Categories.FirstOrDefault(x => x.Name == name);
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            var updateCategory = await this._moocDBContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
            if (updateCategory != null)
            {
                updateCategory.Level = category.Level;
                updateCategory.Name = category.Name;
                updateCategory.ParentId = category.ParentId;

                await this._moocDBContext.SaveChangesAsync();
                return updateCategory;
            }

            return category;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var deleteCategory = await this._moocDBContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (deleteCategory != null)
            {
                this._moocDBContext.Categories.Remove(deleteCategory);
                return await this._moocDBContext.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}
