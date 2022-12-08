using AutoMapper;
using Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Dtos;
using Models.Entities;
using Service.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService :
        Service<User, IUserRepository>, IUserService, IService<User>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;

        public UserService(IUserRepository repository, IHttpContextAccessor httpContextAccessor, IMapper mapper)
            : base(repository)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
        }

        public IEnumerable<UserDto> GetAllDto()
        {
            return GetAll().Select(x => mapper.Map<UserDto>(x));
        }

        public UserDto GetDto(Guid id)
        {
            return mapper.Map<UserDto>(GetById(id));
        }
    }
}
