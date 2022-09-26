using System.ComponentModel.DataAnnotations;

namespace webstory.Dtos
{
    public record CreateCommentDto
    {
        [Required]
        public string idUser { get; init; }
        [Required]
        public string idStory { get; init; }
        [Required]
        public string content { get; init; }


    }
}