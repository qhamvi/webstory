using System;
using System.Collections.Generic;
using System.Linq;
using webstory.Entities;
namespace webstory.Repositories
{
    public class InMemStoriesRepository : SStoriesRepository
    {
        private static List<Story> stories = new()
        {
            new Story
            {
                id = Guid.NewGuid(),
                titleStory = "Cau truyen1",
                author = "vivi",
                collector = "vi22",
                topic = new List<string> { "Hello", "Xin chào", "Hula" },
                complete = false,
                status = false,
                createDate = DateTimeOffset.UtcNow,
                publishDate = DateTimeOffset.UtcNow,
                ImageFileName = "anh.png",

                summary = "Tom tat cua truyen 1 la ......",
                listChap = new List<string>  { "idChap1", "idChap2" },
                idCom = new List<string>  { "idCom1", "idCom2" }
            },

            new Story
            {
                id = Guid.NewGuid(),
                titleStory = "Cau truyen2",
                author = "vivi",
                collector = "vi22",
                topic = new List<string>  { "Hello", "Xin chào", "Hula" },
                complete = false,
                status = false,
                createDate = DateTimeOffset.UtcNow,
                publishDate = DateTimeOffset.UtcNow,
                ImageFileName = "anh.png",
                summary = "Tom tat cua truyen 1 la ......",
                listChap = new List<string>  { "idChap1", "idChap2" },
                idCom = new List<string>  { "idCom1", "idCom2" }
            },

            new Story
            {
                id = Guid.NewGuid(),
                titleStory = "Cau truyen3",
                author = "vivi",
                collector = "vi22",
                topic = new List<string>  { "Hello", "Xin chào", "Hula" },
                complete = false,
                status = false,
                createDate = DateTimeOffset.UtcNow,
                publishDate = DateTimeOffset.UtcNow,
                ImageFileName = "anh.png",
                summary = "Tom tat cua truyen 1 la ......",
                listChap = new List<string>  { "idChap1", "idChap2" },
                idCom = new List<string>  { "idCom1", "idCom2" }
            }
        };
        public IEnumerable<Story> GetStories()
        {
            return stories;
        }
        public IEnumerable<Story> GetStoriesTrue()
        {
            var stories2 = stories.Where(story2 => story2.status == true);
            return stories2;
        }
        public Story GetStory(Guid idStory)
        {
            return stories.Where(story => story.id == idStory).SingleOrDefault();
        }
        public void CreateStory(Story story)
        {
            stories.Add(story);

        }
        public void UpdateStory(Story story)
        {
            var index = stories.FindIndex(existingStory => existingStory.id == story.id);
            stories[index] = story;
        }

        public void DeleteStory(Guid idStory)
        {
            var index = stories.FindIndex(existingStory => existingStory.id == idStory);
            stories.RemoveAt(index);
        }

        public IEnumerable<Story> GetStoriesFull()
        {
            var stories2 = stories.Where(story2 => story2.status == true && story2.complete == true).ToList();
            return stories2;
        }

        public List<Story> GetStoriesTopic(string nametopic)
        {
            return stories.Where(story2 => story2.status == true && story2.topic.Contains(nametopic) == true).ToList();

        }

    }
}