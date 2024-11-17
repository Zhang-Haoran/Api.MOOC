namespace Api.MOOC.ViewModels
{
    public class LoginOutput
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
        public string AccessToken { get; set; }
    }
}
