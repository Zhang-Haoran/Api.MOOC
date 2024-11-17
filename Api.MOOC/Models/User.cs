using System.ComponentModel.DataAnnotations;

namespace Api.MOOC.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string UserName { get; set; }

        [Required, MaxLength(255)]
        public string Password { get; set; }

        [Required, MaxLength(255)]
        public string Email { get; set; }

        public string? Address {  get; set; }

        public int? Age { get; set; }

        public int Gender { get; set; }

        public string? Phone { get; set; }

        public string? Avatar { get; set; }

        public string? Nickname { get; set; }

        public int Access { get;set; }

        public bool Active { get; set; } = true;
    }
}
