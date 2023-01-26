namespace Models.Dtos
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public record LoginDto
    {
        [Required]
        public string Username { get; init; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; init; }
    }
}
