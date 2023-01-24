using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
