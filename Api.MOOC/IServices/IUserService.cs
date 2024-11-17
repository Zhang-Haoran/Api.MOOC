using Api.MOOC.Models;

namespace Api.MOOC.IServices
{
    public interface IUserService
    {
        User Add(User user);
        List<User> GetUsers();
        Task<User> UpdateUsersAsync(User user);
        Task<bool> DeleteUserAsync(int id);
    }
}
