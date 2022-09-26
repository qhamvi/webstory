using System;
using System.Collections.Generic;
using webstory.Entities;

namespace webstory.Repositories
{
    public interface CCommentsRepository
    {
        Comment GetComment(Guid idComment);
        IEnumerable<Comment> GetComments();

        void CreateComment (Comment comment);
        void UpdateComment (Comment comment);
        void DeleteComment (Guid idComment);
    }
}