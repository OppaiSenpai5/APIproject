namespace Service.Services
{
    using Models.Dtos;
    using Models.Entities;
    using Service.Exceptions;
    using Service.Repositories.Interfaces;
    using Service.Services.Interfaces;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    public class AnimeService :
        Service<Anime, IAnimeRepository>, IAnimeService, IService<Anime>
    {
        private readonly IMapper mapper;
        private readonly IUserAnimeRepository userAnimeRepository;
        private readonly IUserRepository userRepository;

        public AnimeService(IAnimeRepository repository,
            IMapper mapper,
            IUserAnimeRepository userAnimeRepository,
            IUserRepository userRepository)
            : base(repository)
        {
            this.mapper = mapper;
            this.userAnimeRepository = userAnimeRepository;
            this.userRepository = userRepository;
        }

        public Anime Create(AnimeDto animeDto)
        {
            if (this.repository.ExistsByTitle(animeDto.Title))
            {
                throw new BadRequestException(
                    new { errorMessage = "An anime with that name already exists." });
            }

            Anime anime = mapper.Map<Anime>(animeDto);
            Create(anime);
            return anime;
        }

        public IEnumerable<AnimeDto> GetAllDto() =>
            GetAll().Select(a => mapper.Map<AnimeDto>(a)).ToList();

        public AnimeDto GetDtoById(Guid id) =>
            mapper.Map<AnimeDto>(GetById(id));

        public IEnumerable<AnimeDto> Search(string query)
        {
            return this.GetAll()
                .Where(a => a.Title.Contains(query,
                    StringComparison.OrdinalIgnoreCase))
                .Select(x => this.mapper.Map<AnimeDto>(x));
        }

        public void Update(Guid id, AnimeDto animeDto)
        {
            var anime = mapper.Map<Anime>(animeDto) with { Id = id };
            Update(anime);
        }

        public IEnumerable<AnimeDto> UserFavourites(Guid userId)
        {
            if (!this.userRepository.ExistsById(userId))
                throw new NotFoundException(new { errorMessage = "User not found." });

            return this.userAnimeRepository.GetAll()
                .Where(ua => ua.UserId == userId)
                .Include(ua => ua.Anime)
                .Select(ua => this.mapper.Map<AnimeDto>(ua.Anime));
        }
    }
}
