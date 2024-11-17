using System.ComponentModel.DataAnnotations;

namespace Api.MOOC.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int Level {  get; set; }

        [Required]
        public int ParentId { get; set; }

        public Category? Parent { get; set; }

        public string? Remark { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
