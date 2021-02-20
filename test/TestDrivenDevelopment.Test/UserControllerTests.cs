using System;
using NSubstitute;
using TestDrivenDevelopment.Models;
using TestDrivenDevelopment.Repository;
using Xunit;

namespace TestDrivenDevelopment.Test
{
    public class UserControllerTests
    {
        private readonly UserController _sut;
        private readonly IUserRepository _userRepository;

        public UserControllerTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _sut = new UserController(_userRepository);
        }

        [Fact]
        public void AddUser_ShouldAddUser_WhenAllInputsAreValid()
        {
            // Arrange
            var user = new User()
            {
                Email = "asghar@gmail.com",
                FirstName = "Asghar",
                LastName = "Asghari",
                DateOfBirth = new DateTime(1980, 1, 1)
            };

            // Act
            _sut.AddUser(user);

            //Assert
            _userRepository.Received(1).AddUser(user);
        }
    }
}