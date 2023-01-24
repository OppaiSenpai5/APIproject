using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
