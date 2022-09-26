using webstory.Dtos;
using webstory.Entities;

namespace webstory
{
    public static class Extensions
    {
        public static TopicDto AsTopicDto(this Topic topic)
        {
            return new TopicDto
            {
                id = topic.id,
                nameTopic = topic.nameTopic
            };
        }
        public static RoleDto AsRoleDto(this Role role)
        {
            return new RoleDto
            {
                id = role.id,
                nameRole = role.nameRole
            };
        }
        public static CommentDto AsCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                id = comment.id,
                idUser = comment.idUser,
                idStory = comment.idStory,
                content = comment.content,
                dateCom = comment.dateCom
            };
        }
        public static ChapterDto AsChapterDto(this Chapter chapter)
        {
            return new ChapterDto
            {
                id = chapter.id,
                titleChap = chapter.titleChap,
                idStory = chapter.idStory,
                collector = chapter.collector,
                createDate = chapter.createDate,
                publishDate = chapter.publishDate,
                content = chapter.content
            };
        }
        public static StoryDto AsStoryDto(this Story story)
        {
            return new StoryDto
            {
                id = story.id,
                titleStory = story.titleStory,
                author = story.author,
                collector = story.author,
                topic = story.topic,
                complete = story.complete,
                status = story.status,
                createDate = story.createDate,
                publishDate = story.publishDate,
                ImageFileName = story.ImageFileName,
                summary = story.summary,
                listChap = story.listChap,
                numberChap = story.listChap.Count,
                idCom = story.idCom
            };
        }
        public static UserDto AsUserDto(this User user)
        {
            return new UserDto
            {
                id = user.id,
                username = user.username,
                password = user.password,
                PhotoFileName = user.PhotoFileName,
                idRole = user.idRole,
                fullName = user.fullName,
                phone = user.phone,
                email = user.email,
                country = user.country,
                createDate = user.createDate,
                like = user.like,
                history = user.history
            };
        }
        public static StoryDto AsStoryTrueDto(this Story story)
        {
            return new StoryDto
            {
                id = story.id,
                titleStory = story.titleStory,
                author = story.author,
                collector = story.author,
                topic = story.topic,
                complete = story.complete,
                status = true,
                createDate = story.createDate,
                publishDate = story.publishDate,
                ImageFileName = story.ImageFileName,
                summary = story.summary,
                listChap = story.listChap,
                numberChap = story.listChap.Count,
                idCom = story.idCom
            };
        }

        public static StoryDto AsStoryFullDto(this Story story)
        {
            return new StoryDto
            {
                id = story.id,
                titleStory = story.titleStory,
                author = story.author,
                collector = story.author,
                topic = story.topic,
                complete = true,
                status = true,
                createDate = story.createDate,
                publishDate = story.publishDate,
                ImageFileName = story.ImageFileName,
                summary = story.summary,
                listChap = story.listChap,
                numberChap = story.listChap.Count,
                idCom = story.idCom
            };
        }
    }
}