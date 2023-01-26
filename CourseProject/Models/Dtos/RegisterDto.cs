namespace Models.Dtos
{
    using System.ComponentModel.DataAnnotations;
    
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
