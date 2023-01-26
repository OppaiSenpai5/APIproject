namespace Service.Services
{
    using System.Security.Claims;

    using Models.Dtos;
    using Models.Entities;
    using Service.Repositories.Interfaces;
    using Service.Services.Interfaces;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;

    public class UserService :
        Service<User, IUserRepository>, IUserService, IService<User>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;
        private readonly IUserAnimeService userAnimeService;
        private string currentUserId =>
            this.httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public UserService(IUserRepository repository,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            IUserAnimeService userAnimeService)
            : base(repository)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
            this.userAnimeService = userAnimeService;
        }

        public IEnumerable<UserDto> GetAllDto()
        {
            return GetAll().Select(x => mapper.Map<UserDto>(x));
        }

        public UserDto GetDto(Guid id)
        {
            return mapper.Map<UserDto>(GetById(id));
        }

        public void AddFavouriteAnime(Guid id)
        {
            var userId = Guid.Parse(currentUserId);
            this.userAnimeService.Create(new UserAnime { AnimeId = id, UserId = userId });
        }
    }
}
