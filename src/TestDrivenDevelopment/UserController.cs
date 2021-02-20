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
            ValidateUser(user);

            return _userRepository.AddUser(user);
        }

        public User GetUserById(string userId)
        {
            throw new System.NotImplementedException();
        }
        
        private void ValidateUser(User user)
        {
            ValidateAge(user.DateOfBirth);
            ValidateEmail(user.Email);
            ValidateId(user.Id);
            ValidateFirstName(user.FirstName);
            ValidateLastName(user.LastName);
        }

        private void ValidateAge(DateTime dateOfBirth)
        {
            var age = GetAge(dateOfBirth);

            if (age < 18)
            {
                throw new ArgumentException("Age is under 18.");
            }
        }

        private static void ValidateLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }
        }

        private static void ValidateFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }
        }

        private static void ValidateId(string userId)
        {
            if (!string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentException("ID is specified.");
            }
        }

        private static void ValidateEmail(string email)
        {
            if (!IsValid(email))
            {
                throw new ArgumentException("Email is not valid.");
            }
        }

        private static bool IsValid(string email)
        {
            try
            {
                _ = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private int GetAge(DateTime dateOfBirth)
        {
            var now = _dateTimeProvider.Now;
            var age = Convert.ToInt32((now - dateOfBirth).TotalDays / 365);
            return age;
        }
    }
}