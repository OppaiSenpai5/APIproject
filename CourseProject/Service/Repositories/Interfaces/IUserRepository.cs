using Models.Dtos;
using Models.Entities;

namespace Service.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);
        bool ExistsByUsername(RegisterDto registration);
        bool ExistsByEmail(RegisterDto registration);
    }
}
