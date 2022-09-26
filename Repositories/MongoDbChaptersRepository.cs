using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using webstory.Entities;

namespace webstory.Repositories
{
    public class MongoDbChaptersRepository : CChaptersRepository
    {
        private const string databaseName = "webstory" ;
        private const string collectionName = "chapters" ;
        private readonly IMongoCollection<Chapter> chaptersCollection ;
        private readonly FilterDefinitionBuilder<Chapter> filterBuilder = Builders<Chapter>.Filter;

        public MongoDbChaptersRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            chaptersCollection = database.GetCollection<Chapter>(collectionName);
        }

        public void CreateChapter(Chapter chapter)
        {
            chaptersCollection.InsertOne(chapter) ;
        }

        public void DeleteChapter(Guid idChapter)
        {
            var filter = filterBuilder.Eq(chapter => chapter.id, idChapter);
            chaptersCollection.DeleteOne(filter);
        }

        public Chapter GetChapter(Guid idChapter)
        {
            var filter = filterBuilder.Eq(chapter => chapter.id, idChapter);
            return chaptersCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Chapter> GetChapters()
        {
            return chaptersCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateChapter(Chapter chapter)
        {
            var filter = filterBuilder.Eq(existingChapter => existingChapter.id , chapter.id);
            chaptersCollection.ReplaceOne(filter,chapter);
        }
    }

}