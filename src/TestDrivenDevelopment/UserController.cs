using System;
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
            var now = DateTime.Now;
            var age = Convert.ToInt32((now - user.DateOfBirth).TotalDays / 365);

            if (age < 18)
            {
                throw new ArgumentException("Age is under 18.");
            }
            
            return _userRepository.AddUser(user);
        }

        public User GetUserById(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}