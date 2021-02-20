using TestDrivenDevelopment.Models;

namespace TestDrivenDevelopment.Repository
{
    public interface IUserRepository
    {
        string AddUser(User user);
        User GetUserById(string userId);
    }
}