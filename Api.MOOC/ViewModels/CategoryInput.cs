using Microsoft.AspNetCore.Mvc;

namespace Api.MOOC.ViewModels
{
    public class BaseCategoryInput
    {
        public string Name { get; set; }

        public int Level { get; set; }

        public int ParentId { get; set; }

    }

    public class AddCategoryInput : BaseCategoryInput
    {

    }
    public class UpdateCategoryInput : BaseCategoryInput
    {
        public int Id { get; set; }
    }
}
