using Models.Dtos;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IUserService : IService<User>
    {
        IEnumerable<UserDto> GetAllDto();
        UserDto GetDto(Guid id);
    }
}
