namespace Service.Services.Interfaces
{
    using Models.Dtos;

    public interface IAuthService
    {
        string GenerateToken(LoginDto login);
        void Register(RegisterDto registration);
    }
}
