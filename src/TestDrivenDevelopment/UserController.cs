using TestDrivenDevelopment.Models;
using TestDrivenDevelopment.Repository;

namespace TestDrivenDevelopment
{
    public class UserController : IUserController
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        public User GetUserById(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}