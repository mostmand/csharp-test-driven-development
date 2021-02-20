using TestDrivenDevelopment.Models;

namespace TestDrivenDevelopment.Repository
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User GetUserById(string userId);
    }
}