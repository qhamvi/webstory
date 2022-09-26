using System;
using System.Collections.Generic;
using webstory.Entities;

namespace webstory.Repositories
{
    public interface TTopicsRepository
    {
        Topic GetTopic(Guid idTopic);
        IEnumerable<Topic> GetTopics();

        void CreateTopic(Topic topic);
        void UpdateTopic(Topic topic);

        void DeleteTopic(Guid idTopic);
    }
}