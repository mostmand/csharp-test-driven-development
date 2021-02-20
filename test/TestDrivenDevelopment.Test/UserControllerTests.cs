using System;
using FluentAssertions;
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
        private readonly IDateTimeProvider _dateTimeProvider;

        public UserControllerTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _dateTimeProvider = Substitute.For<IDateTimeProvider>();
            _sut = new UserController(_userRepository, _dateTimeProvider);
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
            _userRepository.AddUser(user).Returns(new User()
            {
                Id = "1234",
                Email = "asghar@gmail.com",
                FirstName = "Asghar",
                LastName = "Asghari",
                DateOfBirth = new DateTime(1980, 1, 1)
            });

            // Act
            var actual = _sut.AddUser(user);

            //Assert
            _userRepository.Received(1).AddUser(user);

            actual.Id.Should().Be("1234");
            actual.Email.Should().Be("asghar@gmail.com");
            actual.FirstName.Should().Be("Asghar");
            actual.LastName.Should().Be("Asghari");
            actual.DateOfBirth.Should().Be(new DateTime(1980, 1, 1));
        }

        [Fact]
        public void AddUser_ShouldThrowArgumentException_WhenAgeIsUnder18()
        {
            // Arrange
            var user = new User()
            {
                Email = "asghar@gmail.com",
                FirstName = "Asghar",
                LastName = "Asghari",
                DateOfBirth = new DateTime(2013, 2, 4)
            };
            _dateTimeProvider.Now.Returns(new DateTime(2021, 2, 21));
            
            // Act and assert
            Action action = () => _sut.AddUser(user);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}