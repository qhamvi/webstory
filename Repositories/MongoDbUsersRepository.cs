using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using webstory.Entities;

namespace webstory.Repositories
{
    public class MongoDbUsersRepository : UUsersRepository
    {
        private const string databaseName = "webstory";
        private const string collectionName = "users";
        private readonly IMongoCollection<User> usersCollection ;
        private readonly FilterDefinitionBuilder<User> filterBuilder = Builders<User>.Filter;

        public MongoDbUsersRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName) ;
            usersCollection = database.GetCollection<User>(collectionName);
        }

        public void CreateUser(User user)
        {
            usersCollection.InsertOne(user);
        }

        public void DeleteUser(Guid idUser)
        {
            var filter = filterBuilder.Eq(user => user.id ,idUser) ;
            usersCollection.DeleteOne(filter);
        }

        public User GetUser(Guid idUser)
        {
            var filter = filterBuilder.Eq(user => user.id, idUser);
            return usersCollection.Find(filter).SingleOrDefault(); 
        }
        public User LoginUser(string username, string password)
        {
            var filter = filterBuilder.Where(user => user.username == username && user.password == password); 
            return usersCollection.Find(filter).SingleOrDefault(); 
        }

        public IEnumerable<User> GetUsers()
        {
            return usersCollection.Find(new BsonDocument()).ToList();
        }


        public void UpdateUser(User user)
        {
            var filter = filterBuilder.Eq(existingUser=> existingUser.id, user.id);
            usersCollection.ReplaceOne(filter,user); 
        }
    }
}