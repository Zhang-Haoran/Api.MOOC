using Api.MOOC.IServices;
using Api.MOOC.Models;

namespace Api.MOOC.Services
{
    public class UserService: IUserService
    {
        private readonly MoocDbContext _dbContext;

        public UserService(MoocDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public List<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public async Task<User> UpdateUsersAsync(User user)
        {
            var existingUser = await _dbContext.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.UserName = user.UserName;
            existingUser.Password = user.Password;
            existingUser.Email = user.Email;
            existingUser.Address = user.Address;
            existingUser.Age = user.Age;
            existingUser.Gender = user.Gender;
            existingUser.Avatar = user.Avatar;
            existingUser.Nickname = user.Nickname;
            existingUser.Access = user.Access;
            existingUser.Active = user.Active;

            _dbContext.Users.Update(existingUser);
            await _dbContext.SaveChangesAsync();

            return existingUser;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
