using System;
using System.Net.Mail;
using TestDrivenDevelopment.Models;
using TestDrivenDevelopment.Repository;

namespace TestDrivenDevelopment
{
    public class UserController : IUserController
    {
        private readonly IUserRepository _userRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public UserController(IUserRepository userRepository,
            IDateTimeProvider dateTimeProvider)
        {
            _userRepository = userRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public User AddUser(User user)
        {
            var age = GetAge(user.DateOfBirth);

            if (age < 18)
            {
                throw new ArgumentException("Age is under 18.");
            }

            ValidateEmail(user.Email);
            
            return _userRepository.AddUser(user);
        }

        private static void ValidateEmail(string email)
        {
            try
            {
                new MailAddress(email);
            }
            catch
            {
                throw new ArgumentException("Email is not valid.");
            }
        }

        private int GetAge(DateTime dateOfBirth)
        {
            var now = _dateTimeProvider.Now;
            var age = Convert.ToInt32((now - dateOfBirth).TotalDays / 365);
            return age;
        }

        public User GetUserById(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}