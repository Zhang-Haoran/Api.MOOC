using Api.MOOC.Enum;

namespace Api.MOOC.ViewModels
{
    public class UserOutput
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        public Gender Gender { get; set; }
        public string? Phone { get; set; }
        public int Access { get; set; }
    }
}
