using System.ComponentModel.DataAnnotations;

namespace webstory.Dtos
{
    public record CreateTopicDto
    {
        [Required]
        public string[] nameTopic { get; init; }

    }
}