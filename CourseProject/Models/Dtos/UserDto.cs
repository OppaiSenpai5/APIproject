using Models.Enums;

namespace Models.Dtos
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
