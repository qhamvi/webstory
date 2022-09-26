using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using webstory.Entities;

namespace webstory.Repositories
{
    public class MongoDbRolesRepository : RRolesRepository
    {
        private const string databaseName = "webstory" ;
        private const string collectionName = "roles" ;

        private readonly IMongoCollection<Role> rolersCollection ;
        private readonly FilterDefinitionBuilder<Role> filterBuilder = Builders<Role>.Filter ;

        public MongoDbRolesRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            rolersCollection = database.GetCollection<Role>(collectionName);
        }

        public void CreateRole(Role role)
        {
            rolersCollection.InsertOne(role);
        }

        public void DeleteRole(Guid idRole2)
        {
            var filter = filterBuilder.Eq(role => role.id ,idRole2);
            rolersCollection.DeleteOne(filter);
        }

        public Role GetRole(Guid idRole2)
        {
            var filter = filterBuilder.Eq(role => role.id, idRole2);
            return rolersCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Role> GetRoles()
        {
            return rolersCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateRole(Role role)
        {
            var filter = filterBuilder.Eq(existingRole => existingRole.id, role.id);
            rolersCollection.ReplaceOne(filter,role);
        }
    }
}