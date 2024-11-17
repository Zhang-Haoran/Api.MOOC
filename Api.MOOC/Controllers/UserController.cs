using Api.MOOC.IServices;
using Api.MOOC.Models;
using Api.MOOC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.MOOC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<User> AddUser(AddUserInput input)
        {
            if (input == null)
            {
                return BadRequest("Input data is null.");
            }

            User user = new User
            {
                UserName = input.UserName,
                Password = input.Password,
                Email = input.Email,
                Address = input.Address,
                Access = input.Access,
            };

            var result = _userService.Add(user);
            return Ok(result);
        }

        [HttpGet]
        public ActionResult<List<UserOutput>> GetUsers()
        {
            var users = _userService.GetUsers();
            var userOutputs = users.Select(user => new UserOutput
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Address = user.Address,
                Gender = (Enum.Gender)user.Gender,
                Access = user.Access,
            }).ToList();

            return Ok(userOutputs);
        }

        // 更新用户信息
        [HttpPut]
        public async Task<ActionResult<UserOutput>> UpdateUserAsync(UpdateUserInput input)
        {
            if (input == null || input.Id <= 0)
            {
                return BadRequest("Invalid input data.");
            }

            User user = new User
            {
                Id = input.Id,
                UserName = input.UserName,
                Password = input.Password,
                Email = input.Email,
                Address = input.Address,
                Access = input.Access,
            };

            var updatedUser = await _userService.UpdateUsersAsync(user);
            if (updatedUser == null)
            {
                return NotFound($"User with Id {input.Id} not found.");
            }

            var userOutput = new UserOutput
            {
                Id = updatedUser.Id,
                UserName = updatedUser.UserName,
                Email = updatedUser.Email,
                Address = updatedUser.Address,
                Gender = (Enum.Gender)updatedUser.Gender,
                Access = updatedUser.Access,
            };

            return Ok(userOutput);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteUserAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid user Id.");
            }

            var result = await _userService.DeleteUserAsync(id);
            if (!result)
            {
                return NotFound($"User with Id {id} not found.");
            }

            return Ok(true);
        }
    }
}
