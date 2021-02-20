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
            var age = GetAge(user.DateOfBirth);

            if (age < 18)
            {
                throw new ArgumentException("Age is under 18.");
            }
            
            return _userRepository.AddUser(user);
        }

        private static int GetAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            var age = Convert.ToInt32((now - dateOfBirth).TotalDays / 365);
            return age;
        }

        public User GetUserById(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}