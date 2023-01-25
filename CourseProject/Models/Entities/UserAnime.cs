namespace Models.Entities
{
    public record UserAnime : Entity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid AnimeId { get; set; }
        public Anime Anime { get; set; }
    }
}
