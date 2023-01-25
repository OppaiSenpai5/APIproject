using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public abstract record Entity
    {
        [Key]
        public Guid Id { get; init; }

        public Entity() => Id = Guid.NewGuid();
    }
}
