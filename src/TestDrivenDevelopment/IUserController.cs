using System;
using System.Collections.Generic;
using TestDrivenDevelopment.Models;

namespace TestDrivenDevelopment
{
    public interface IUserController
    {
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>The created user including its Id</returns>
        /// <exception cref="ArgumentException">
        /// When age is under 18
        /// When email is not a valid email address
        /// When ID is specified
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// When FirstName or LastName is null or whitespace
        /// </exception>
        User AddUser(User user);

        /// <summary>
        /// Gets the stored user specified by the given ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>The user with the given ID</returns>
        /// <exception cref="ArgumentNullException">
        /// When <see cref="userId"/> is null or whitespace
        /// </exception>
        /// <exception cref="KeyNotFoundException">
        /// When no user is available with the given <see cref="userId"/>
        /// </exception>
        User GetUserById(string userId);
    }
}