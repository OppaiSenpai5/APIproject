using CourseProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CourseProject.Data.Seed.XML
{
    [XmlRoot("animes_list")]
    public record AnimesList
    {
        [XmlArray("list")]
        public Anime[] List { get; set; }
    }
}
