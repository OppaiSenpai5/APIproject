namespace Service.Repositories.Interfaces
{
    using Models.Dtos;
    using Models.Entities;

    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);
        bool ExistsByUsername(RegisterDto registration);
        bool ExistsByEmail(RegisterDto registration);
    }
}
