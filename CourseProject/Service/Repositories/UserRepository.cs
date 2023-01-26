namespace Service.Repositories
{
    using Models.Dtos;
    using Models.Entities;
    using Persistence;
    using Service.Repositories.Interfaces;

    public class UserRepository : Repository<User>, IUserRepository, IRepository<User>
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public bool ExistsByEmail(RegisterDto registration) =>
            this.dbSet.Any(u => u.Email == registration.Email);

        public bool ExistsByUsername(RegisterDto registration) =>
            this.dbSet.Any(u => u.Username == registration.Username);

        public User GetByUsername(string username) =>
            this.dbSet.SingleOrDefault(u => u.Username == username)!;
    }
}
