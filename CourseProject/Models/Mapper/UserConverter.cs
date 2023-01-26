namespace Models.Mapper
{
    using System.Security.Cryptography;
    using System.Text;

    using Models.Dtos;
    using Models.Entities;
    
    using AutoMapper;

    public class UserConverter : ITypeConverter<RegisterDto, User>, ITypeConverter<LoginDto, User>
    {
        public User Convert(RegisterDto source, User destination, ResolutionContext context)
        {
            using (var hmac = new HMACSHA512())
            {
                var passwordSalt = hmac.Key;
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(source.Password));

                return new User
                {
                    Username = source.Username,
                    Email = source.Email,
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash
                };
            }
        }

        public User Convert(LoginDto source, User destination, ResolutionContext context)
        {
            using (var hmac = new HMACSHA512(destination.PasswordSalt))
            {
                return destination with
                {
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(source.Password))
                };
            }
        }
    }
}
