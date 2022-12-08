using Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(LoginDto login);
        void Register(RegisterDto registration);
    }
}
