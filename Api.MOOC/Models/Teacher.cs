using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.MOOC.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public string? Introduction { get; set; }

        public string? Expertise { get; set; }

        public string? Organization { get; set; }

        public string? Department { get; set; }

        public string? Level { get; set; }
    }
}
