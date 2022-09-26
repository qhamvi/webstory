using System.ComponentModel.DataAnnotations;

namespace webstory.Dtos
{
    public record CreateRoleDto
    {
        [Required]
        public string nameRole { get; init; }

    }
}