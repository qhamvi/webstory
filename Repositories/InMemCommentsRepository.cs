using System;
using System.Collections.Generic;
using System.Linq;
using webstory.Entities;

namespace webstory.Repositories
{
        public class InMemCommentsRepository : CCommentsRepository
    {

        private static List<Comment> comments = new()
        {
            new Comment { id = Guid.NewGuid(), idUser = "Admin", idStory = "Truyen1", content = "Vidu1...", dateCom = DateTimeOffset.UtcNow },
            new Comment { id = Guid.NewGuid(), idUser = "Collector", idStory = "Truyen2", content = "Vidu2...", dateCom = DateTimeOffset.UtcNow },
            new Comment { id = Guid.NewGuid(), idUser = "Member", idStory = "Truyen4", content = "Vidu3...", dateCom = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Comment> GetComments()
        {
            return comments;
        }

        public Comment GetComment(Guid idComment)
        {
            return comments.Where(comment => comment.id == idComment).SingleOrDefault();
        }

        public void CreateComment(Comment comment)
        {
            comments.Add(comment);
        }

        public void UpdateComment(Comment comment)
        {
            var index = comments.FindIndex(existingComment => existingComment.id == comment.id);
            comments[index] = comment;
        }

        public void DeleteComment(Guid idComment)
        {
            var index = comments.FindIndex(existingComment => existingComment.id ==idComment);
            comments.RemoveAt(index);
            
        }
    }
}