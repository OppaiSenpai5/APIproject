using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Dtos;
using Models.Entities;
using Service.Exceptions;
using Service.Repositories.Interfaces;
using Service.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration config;
        private readonly IUserRepository repo;
        private readonly IMapper mapper;

        private string key => config["Jwt:Key"];
        private string issuer => config["Jwt:Issuer"];
        private string audience => config["Jwt:Audience"];

        public AuthService(IConfiguration config, IUserRepository repo, IMapper mapper)
        {
            this.config = config;
            this.repo = repo;
            this.mapper = mapper;
        }

        public string GenerateToken(LoginDto login)
        {
            var user = Authenticate(login);

            if (user is null)
            {
                throw new BadRequestException(new { error = "Wrong username or password." });
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(LoginDto login)
        {
            if (repo.GetByUsername(login.Username) is User user)
            {
                var mappedUser = mapper.Map(login, user);
                if (user.PasswordHash.SequenceEqual(mappedUser.PasswordHash))
                    return user;
            }

            return null!;
        }

        public void Register(RegisterDto registration)
        {
            if (repo.ExistsByUsername(registration))
            {
                throw new BadRequestException(new { errorMessage = "This username is already taken" });
            }

            if (repo.ExistsByEmail(registration))
            {
                throw new BadRequestException(new { errorMessage = "This email is already taken" });
            }

            var user = mapper.Map<User>(registration);
            repo.Create(user);
        }
    }
}
