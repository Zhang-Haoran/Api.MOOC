using Api.MOOC.IServices;
using Api.MOOC.Models;
using Api.MOOC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.MOOC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase {

        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;

        }

        [HttpPost]
        public Category AddCategory(AddCategoryInput input)
        {
            Category category = new Category();
            category.Name = input.Name;
            category.Level = input.Level;
            category.ParentId = input.ParentId;
            var result = this._categoryService.Add(category);
            return result;
        }

        [HttpGet]
        public List<CategoryOutput> GetCategory()
        {
            var result = this._categoryService.GetCategories();
            List<CategoryOutput> resultList = new List<CategoryOutput>();
            foreach (var category in result)
            {
                var output = new CategoryOutput();
                output.Id = category.Id;
                output.Name = category.Name;
                output.Level = category.Level;
                output.ParentId = category.ParentId;

                resultList.Add(output);
            }
            return resultList;
        }

        [HttpPut]
        public async Task<CategoryOutput> UpdateCategoryAsync(UpdateCategoryInput input)
        {

            Category category = new Category();
            category.Id = input.Id;
            category.Name = input.Name;
            category.Level = input.Level;
            category.ParentId = input.ParentId;

            var reslutCategory = await this._categoryService.UpdateCategoryAsync(category);

            var categoryOutput = new CategoryOutput()
            {
                Id = reslutCategory.Id,
                Name = reslutCategory.Name,
                Level = reslutCategory.Level
            };
            return categoryOutput;

        }

        [HttpDelete]
        public async Task<bool> DeleteCategoryAsync(int Id)
        {
            bool result = await this._categoryService.DeleteCategoryAsync(Id);
            return result;
        }


    }
}
