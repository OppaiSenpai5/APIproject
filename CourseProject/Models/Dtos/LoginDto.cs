using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.Dtos
{
    public record LoginDto
    {
        [Required]
        public string Username { get; init; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; init; }
    }
}
