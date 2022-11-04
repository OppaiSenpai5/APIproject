using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CourseProject.Data.Entities
{
    [XmlType("anime")]
    public record Anime : BaseEntity
    {
        [Required]
        [XmlElement("title")]
        public string Title { get; init; }

        [Range(0, int.MaxValue)]
        [XmlElement("episode_count")]
        public int? EpisodeCount { get; init; }

        [XmlElement("date_start")]
        public DateTime? StartDate { get; init; }

        [XmlElement("date_end")]
        public DateTime? EndDate { get; init; }

        [Range(0, 10)]
        [XmlElement("score")]
        public double? Score { get; init; }

        [XmlElement("synopsis")]
        public string? Synopsis { get; init; }
    }
}
