using System.ComponentModel.DataAnnotations;

namespace webstory.Dtos
{
    public record UpdateTopicDto
    {
        [Required]
        public string[] nameTopic { get; init; }

    }
}