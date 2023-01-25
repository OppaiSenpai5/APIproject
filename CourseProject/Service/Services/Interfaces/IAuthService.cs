using Models.Dtos;

namespace Service.Services.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(LoginDto login);
        void Register(RegisterDto registration);
    }
}
