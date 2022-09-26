using System;
using System.Collections.Generic;
using System.Linq;
using webstory.Entities;

namespace webstory.Repositories
{
    

    public class InMemUsersRepository : UUsersRepository
    {
        private readonly List<User> users = new()
        {
            new User
            {
                id = Guid.NewGuid(),
                username = "vivi1",
                password = "12345",
                PhotoFileName = "photo",
                idRole = "admin",
                fullName = "Pham Vi",
                phone = "0987654321",
                email = "q@gmail.com",
                country = "Kien Giang",
                createDate = DateTimeOffset.UtcNow,
                like = new string[] { "truyen1", "truyen2" },
                history = new string[] { "helll", "helll" }
            },

            new User
            {
                id = Guid.NewGuid(),
                username = "vivi2",
                password = "12345",
                PhotoFileName = "photo",
                idRole = "admin",
                fullName = "Pham Vi",
                phone = "0987654321",
                email = "q@gmail.com",
                country = "Kien Giang",
                createDate = DateTimeOffset.UtcNow,
                like = new string[] { "truyen1", "truyen2" },
                history = new string[] { "helll", "helll" }
            },

            new User
            {
                id = Guid.NewGuid(),
                username = "vivi3",
                password = "12345",
                PhotoFileName = "photo",
                idRole = "admin",
                fullName = "Pham Vi",
                phone = "0987654321",
                email = "q@gmail.com",
                country = "Kien Giang",
                createDate = DateTimeOffset.UtcNow,
                like = new string[] { "truyen1", "truyen2" },
                history = new string[] { "helll", "helll" }
            },

        };

        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public User GetUser(Guid idUser)
        {
            return users.Where(user => user.id == idUser).SingleOrDefault();
        }
        public User LoginUser(string username, string password)
        {
            return users.Where(user => user.username == username && user.password == password).SingleOrDefault(); 
        }
        public void CreateUser(User user)
        {
            users.Add(user);
        }
        public void UpdateUser(User user)
        {
            var index = users.FindIndex(existingUser => existingUser.id == user.id);
            users[index] = user;
        }
        public void DeleteUser(Guid idUser)
        {
            var index = users.FindIndex(existingUser => existingUser.id == idUser);
            users.RemoveAt(index);
        }

        
    }
}