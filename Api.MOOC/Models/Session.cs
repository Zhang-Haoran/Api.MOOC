using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.MOOC.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }

        [Required, MaxLength(255)]
        public string Title { get; set; }

        public string? Description { get; set; }

        public string? MediaUrl { get; set; }
    }
}
