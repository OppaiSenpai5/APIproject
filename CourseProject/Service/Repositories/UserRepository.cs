using Models.Dtos;
using Models.Entities;
using Persistence;
using Service.Repositories.Interfaces;

namespace Service.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository, IRepository<User>
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public bool ExistsByEmail(RegisterDto registration)
        {
            return this.dbSet.Any(u => u.Email == registration.Email);
        }

        public bool ExistsByUsername(RegisterDto registration)
        {
            return this.dbSet.Any(u => u.Username == registration.Username);
        }

        public User GetByUsername(string username)
        {
            return this.dbSet.SingleOrDefault(u => u.Username == username)!;
        }
    }
}
