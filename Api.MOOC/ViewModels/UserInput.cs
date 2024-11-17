using Api.MOOC.Enum;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Api.MOOC.ViewModels
{
    public class UserInput
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "User name can't be null")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "email format is not correct")]
        public string? Email { get; set; }
        public string Password { get; set; }

        public string? Address { get; set; }

        public Gender Gender { get; set; }

        [PhoneValidation]
        public string? Phone { get; set; }

        public int Access { get; set; }
    }

    public class AddUserInput : UserInput
    {

    }

    public class UpdateUserInput : UserInput
    {

    }
}
