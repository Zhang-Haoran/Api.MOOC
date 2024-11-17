using Api.MOOC.Models;

namespace Api.MOOC.IServices
{
    public interface ICategoryService
    {
        Category Add(Category category);
        List<Category> GetCategories();
        Category? GetCategoryByName(string name);
        Task<Category> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
