using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using webstory.Entities;

namespace webstory.Repositories
{
    public class MongoDbStoriesRepository : SStoriesRepository
    {
        private const string databaName = "webstory";
        private const string CollectionName = "stories";

        private readonly IMongoCollection<Story> storiesCollection;
        private readonly FilterDefinitionBuilder<Story> filterBuilder = Builders<Story>.Filter;

        public MongoDbStoriesRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaName);
            storiesCollection = database.GetCollection<Story>(CollectionName);
        }

        public void CreateStory(Story story)
        {
            storiesCollection.InsertOne(story);
        }

        public void DeleteStory(Guid idStory)
        {
            var filter = filterBuilder.Eq(story => story.id, idStory);
            storiesCollection.DeleteOne(filter);
        }

        public IEnumerable<Story> GetStories()
        {
            return storiesCollection.Find(new BsonDocument()).ToList();
        }
        public IEnumerable<Story> GetStoriesTrue()
        {
            var filter = filterBuilder.Where(story2 => story2.status == true);

            return storiesCollection.Find(filter).ToList();
        }
        public IEnumerable<Story> GetStoriesFull()
        {
            var filter = filterBuilder.Where(story2 => story2.status == true && story2.complete == true);

            return storiesCollection.Find(filter).ToList();
        }

        public Story GetStory(Guid idStory)
        {
            var filter = filterBuilder.Eq(story => story.id, idStory);
            return storiesCollection.Find(filter).SingleOrDefault();
        }

        public void UpdateStory(Story story)
        {
            var filter = filterBuilder.Eq(existingStory => existingStory.id, story.id);
            storiesCollection.ReplaceOne(filter, story);
        }

        public List<Story> GetStoriesTopic(string nametopic)
        {
            var listAllTopic = new List<Story>();
            var a = GetStories();
            listAllTopic.AddRange(a);

            return listAllTopic.FindAll(story2 => story2.status == true && story2.topic.Contains(nametopic) == true);
        }

    }

}