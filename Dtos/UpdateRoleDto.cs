using System.ComponentModel.DataAnnotations;

namespace webstory.Dtos
{
    public record UpdateRoleDto
    {
        [Required]
        public string nameRole { get; init; }

    }
}