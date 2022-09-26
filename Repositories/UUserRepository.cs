using System;
using System.Collections.Generic;
using webstory.Entities;

namespace webstory.Repositories
{
    public interface UUsersRepository
    {
        void CreateUser(User user);
        void DeleteUser(Guid idUser);
        User GetUser(Guid idUser);
        IEnumerable<User> GetUsers();
        void UpdateUser(User user);
        // Login
        User LoginUser(string username, string password);
    }
}