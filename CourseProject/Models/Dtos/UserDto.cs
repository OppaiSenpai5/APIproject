namespace Models.Dtos
{
    using Models.Enums;

    public class UserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
