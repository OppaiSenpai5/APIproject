using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public abstract record Entity
    {
        [Key]
        public Guid Id { get; init; }

        public Entity() => Id = Guid.NewGuid();
    }
}
