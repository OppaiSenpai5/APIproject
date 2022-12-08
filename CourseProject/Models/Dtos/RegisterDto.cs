using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos
{
    public record RegisterDto
    {
        [Required]
        public string Username { get; init; }
        [Required]
        [EmailAddress]
        public string Email { get; init; }
        [Required]
        [MinLength(8)]
        public string Password { get; init; }
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; init; }
    }
}
