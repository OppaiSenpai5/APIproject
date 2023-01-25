using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Models.Entities
{
    [XmlType("anime")]
    public record Anime : Entity
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

        [XmlIgnore]
        public IEnumerable<UserAnime> UserAnimes { get; set; }
    }
}
