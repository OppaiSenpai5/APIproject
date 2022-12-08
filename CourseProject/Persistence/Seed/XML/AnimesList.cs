using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
