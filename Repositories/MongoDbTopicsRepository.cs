using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using webstory.Entities;

namespace webstory.Repositories
{
    public class MongoDbTopicsRepository : TTopicsRepository
    {
        private const string databaseName = "webstory";
        private const string collectionName = "topics" ;
        private readonly IMongoCollection<Topic> topicsCollection;

        private readonly FilterDefinitionBuilder<Topic> filterBuilder = Builders<Topic>.Filter;
        public MongoDbTopicsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            topicsCollection = database.GetCollection<Topic>(collectionName);
        }

        public void CreateTopic(Topic topic)
        {
            topicsCollection.InsertOne(topic);
        }

        public async Task CreateTopicAsync(Topic topic)
        {
            await topicsCollection.InsertOneAsync(topic);
        }

        public void DeleteTopic(Guid idTopic)
        {
            var filter = filterBuilder.Eq(topic => topic.id ,idTopic) ;
            topicsCollection.DeleteOne(filter);
        }


        public Topic GetTopic(Guid idTopic)
        {
            var filter = filterBuilder.Eq(topic => topic.id, idTopic);
            return topicsCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Topic> GetTopics()
        {
             return topicsCollection.Find(new BsonDocument()).ToList();
        }
        
        public void UpdateTopic(Topic topic)
        {
            var filter = filterBuilder.Eq(existingTopic=> existingTopic.id, topic.id);
            topicsCollection.ReplaceOne(filter,topic); 
        }
        
    }
}