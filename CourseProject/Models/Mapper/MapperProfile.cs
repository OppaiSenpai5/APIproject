namespace Models.Mapper
{
    using Models.Dtos;
    using Models.Entities;
    
    using AutoMapper;

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
