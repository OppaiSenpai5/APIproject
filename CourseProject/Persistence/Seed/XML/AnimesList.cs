using Models.Entities;
using System.Xml.Serialization;

namespace Persistence.Seed.XML
{
    [XmlRoot("animes_list")]
    public class AnimesList
    {
        [XmlArray("list")]
        public Anime[] List { get; set; }
    }
}
