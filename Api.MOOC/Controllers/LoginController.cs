using Api.MOOC.IServices;
using Api.MOOC.Services;
using Api.MOOC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.MOOC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUserService _userService;
        private readonly CreateTokenService _createTokenService;
        public LoginController(IUserService userService, CreateTokenService createTokenService, ILogger<LoginController> logger)
        {
            this._userService = userService;
            this._createTokenService = createTokenService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<LoginOutput> LoginAsync(LoginInput input)
        {
            var user = await this._userService.GetUserbyUserNameAsync(input.UserName);
            this._logger.LogWarning("this is a log warning test");
            this._logger.LogError("this is a log error test");
            this._logger.LogDebug("this is a log debug test");
            if (user == null)
            {
                return null;
            }

            if (user.Password == input.Password)
            {
                Dictionary<string, string> payload = new Dictionary<string, string>();
                payload.Add("UserId", user.Id.ToString());
                payload.Add("UserName", user.UserName);
                payload.Add("Email", user.Email);
                var accessToken = this._createTokenService.CreateToken(payload);

                var result = new LoginOutput()
                {
                    AccessToken = accessToken,
                    UserId = user.Id,
                    UserName = input.UserName,
                };
                return result;
            }

            return null;
        }
    }
}
