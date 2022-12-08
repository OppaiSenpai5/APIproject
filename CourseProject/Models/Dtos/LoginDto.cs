using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
