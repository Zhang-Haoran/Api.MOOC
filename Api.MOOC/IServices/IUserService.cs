using Api.MOOC.Models;

namespace Api.MOOC.IServices
{
    public interface IUserService
    {
        bool AddUser(User user);
        List<User> GetUsers();

        bool UpdateUser(User user);

        bool DeleteUser(int id);

        User GetUserbyUserName(string userName);
    }
}
