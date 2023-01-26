namespace Service.Repositories.Interfaces
{
    using Models.Entities;

    public interface IAnimeRepository : IRepository<Anime>
    {
        bool ExistsByTitle(string title);
    }
}
