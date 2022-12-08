using Models.Dtos;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);
        bool ExistsByUsername(RegisterDto registration);
        bool ExistsByEmail(RegisterDto registration);
    }
}
