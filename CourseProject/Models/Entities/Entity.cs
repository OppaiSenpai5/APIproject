namespace Models.Entities
{
    using System.ComponentModel.DataAnnotations;

    public abstract record Entity
    {
        [Key]
        public Guid Id { get; init; }

        public Entity() => Id = Guid.NewGuid();
    }
}
