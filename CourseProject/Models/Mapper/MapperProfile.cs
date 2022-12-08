using AutoMapper;
using Models.Dtos;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AnimeDto, Anime>().ReverseMap();

            CreateMap<RegisterDto, User>().ConvertUsing(typeof(UserConverter));

            CreateMap<LoginDto, User>().ConvertUsing(typeof(UserConverter));

            CreateMap<User, UserDto>();
        }
    }
}
