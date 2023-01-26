namespace Persistence.Seed.XML
{
    using System.Xml.Serialization;

    using Models.Entities;

    [XmlRoot("animes_list")]
    public class AnimesList
    {
        [XmlArray("list")]
        public Anime[] List { get; set; }
    }
}
