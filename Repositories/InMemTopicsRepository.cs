using System;
using System.Collections.Generic;
using System.Linq;
using webstory.Entities;

namespace webstory.Repositories
{

    public class InMemTopicsRepository : TTopicsRepository
    {
        private static readonly string[] Summaries = new[]
    {
        "Helo", "VD", "Haloo"
    };
        private readonly List<Topic> topics = new()
        {
            // new Topic { id = Guid.NewGuid(), nameTopic=Summaries },

            new Topic { id = Guid.NewGuid(), nameTopic = new string[] { "Hello", "Xin chào", "Hula" } },
            new Topic { id = Guid.NewGuid(), nameTopic = new string[] { "Bye", "Tạm biệt", "baibai" } },
            new Topic { id = Guid.NewGuid(), nameTopic = new string[] { "Class", "Courses", "Lớp" } }

            // new Topic { id = Guid.NewGuid(), nameTopic = { "Class", "Courses", "Lớp" } }, - list ERROR List<string>
        };


        public IEnumerable<Topic> GetTopics()
        {
            return topics;
        }
        public Topic GetTopic(Guid idTopic)
        {
            return topics.Where(topic => topic.id == idTopic).SingleOrDefault();

        }

        public void CreateTopic(Topic topic)
        {
            topics.Add(topic);
        }

        public void UpdateTopic(Topic topic)
        {
            var index = topics.FindIndex(existingTopic => existingTopic.id == topic.id);
            topics[index] = topic;
        }

        public void DeleteTopic(Guid idTopic)
        {
            var index = topics.FindIndex(existingTopic => existingTopic.id == idTopic);
            topics.RemoveAt(index);
        }
    }
}