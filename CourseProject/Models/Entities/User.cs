using Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public record User : Entity
    {
        [Required]
        public string Username { get; init; }
        [Required]
        public byte[] PasswordSalt { get; init; }
        [Required]
        public byte[] PasswordHash { get; init; }
        [Required]
        [EmailAddress]
        public string Email { get; init; }
        [Required]
        public Role Role { get; init; } = Role.User;

        public IEnumerable<UserAnime> UserAnimes { get; set; }
    }
}
