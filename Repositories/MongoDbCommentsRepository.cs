using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using webstory.Entities;

namespace webstory.Repositories
{
    public class MongoDbCommentsRepository : CCommentsRepository
    {
        private const string databaseName = "webstory";
        private const string collectionName = "comments";

        private readonly IMongoCollection<Comment> commentsCollection;
        private readonly FilterDefinitionBuilder<Comment> filterBuilder = Builders<Comment>.Filter;

        public MongoDbCommentsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            commentsCollection = database.GetCollection<Comment>(collectionName);
        }

        public void CreateComment(Comment comment)
        {
            commentsCollection.InsertOne(comment);
        }

        public void DeleteComment(Guid idComment)
        {
            var filter = filterBuilder.Eq(comment => comment.id, idComment);
            commentsCollection.DeleteOne(filter);

        }

        public Comment GetComment(Guid idComment)
        {
            var filter = filterBuilder.Eq(comment => comment.id,idComment);
            return commentsCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Comment> GetComments()
        {
            return commentsCollection.Find(new BsonDocument()).ToList() ;
        }

        public void UpdateComment(Comment comment)
        {
            var filter = filterBuilder.Eq(existingComment => existingComment.id, comment.id);
            commentsCollection.ReplaceOne(filter,comment);
        }
    }
}