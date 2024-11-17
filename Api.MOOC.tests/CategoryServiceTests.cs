

using Api.MOOC.IServices;
using Api.MOOC.Models;
using Moq;

namespace Api.MOOC.tests
{
    public class CategoryServiceTests
    {
        [Fact]
        public void AddCategory_ShouldAddCategory()
        {
            // Arrange
            var mockCategoryService = new Mock<ICategoryService>();
            var newCategory = new Category { Id = 1, Name = "New Category", Level = 1, ParentId = 0 };

            mockCategoryService.Setup(service => service.Add(It.IsAny<Category>())).Returns(newCategory);

            var categoryService = mockCategoryService.Object;

            // Act
            var result = categoryService.Add(newCategory);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("New Category", result.Name);
            mockCategoryService.Verify(service => service.Add(It.IsAny<Category>()), Times.Once);
        }

        [Fact]
        public void GetCategories_ShouldReturnAllCategories()
        {
            // Arrange
            var mockCategoryService = new Mock<ICategoryService>();
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Category 1", Level = 1, ParentId = 0 },
                new Category { Id = 2, Name = "Category 2", Level = 2, ParentId = 1 }
            };

            mockCategoryService.Setup(service => service.GetCategories()).Returns(categories);

            var categoryService = mockCategoryService.Object;

            // Act
            var result = categoryService.GetCategories();

            // Assert
            Assert.Equal(2, result.Count);
            mockCategoryService.Verify(service => service.GetCategories(), Times.Once);
        }

        [Fact]
        public void GetCategoryByName_ShouldReturnCorrectCategory()
        {
            // Arrange
            var mockCategoryService = new Mock<ICategoryService>();
            var category = new Category { Id = 1, Name = "Category 1", Level = 1, ParentId = 0 };

            mockCategoryService.Setup(service => service.GetCategoryByName("Category 1")).Returns(category);

            var categoryService = mockCategoryService.Object;

            // Act
            var result = categoryService.GetCategoryByName("Category 1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Category 1", result.Name);
            mockCategoryService.Verify(service => service.GetCategoryByName("Category 1"), Times.Once);
        }

        [Fact]
        public async Task UpdateCategoryAsync_ShouldUpdateCategory()
        {
            // Arrange
            var mockCategoryService = new Mock<ICategoryService>();
            var updatedCategory = new Category { Id = 1, Name = "Updated Category", Level = 1, ParentId = 0 };

            mockCategoryService.Setup(service => service.UpdateCategoryAsync(It.IsAny<Category>())).ReturnsAsync(updatedCategory);

            var categoryService = mockCategoryService.Object;

            // Act
            var result = await categoryService.UpdateCategoryAsync(updatedCategory);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Updated Category", result.Name);
            mockCategoryService.Verify(service => service.UpdateCategoryAsync(It.IsAny<Category>()), Times.Once);
        }

        [Fact]
        public async Task DeleteCategoryAsync_ShouldDeleteCategory()
        {
            // Arrange
            var mockCategoryService = new Mock<ICategoryService>();

            mockCategoryService.Setup(service => service.DeleteCategoryAsync(It.IsAny<int>())).ReturnsAsync(true);

            var categoryService = mockCategoryService.Object;

            // Act
            var result = await categoryService.DeleteCategoryAsync(1);

            // Assert
            Assert.True(result);
            mockCategoryService.Verify(service => service.DeleteCategoryAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task DeleteCategoryAsync_ShouldReturnFalseIfCategoryNotFound()
        {
            // Arrange
            var mockCategoryService = new Mock<ICategoryService>();

            mockCategoryService.Setup(service => service.DeleteCategoryAsync(It.IsAny<int>())).ReturnsAsync(false);

            var categoryService = mockCategoryService.Object;

            // Act
            var result = await categoryService.DeleteCategoryAsync(999); // Non-existent ID

            // Assert
            Assert.False(result);
            mockCategoryService.Verify(service => service.DeleteCategoryAsync(It.IsAny<int>()), Times.Once);
        }
    }
}