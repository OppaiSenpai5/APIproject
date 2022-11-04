using CourseProject.Data.Entities;
using CourseProject.Data.Seed.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CourseProject.Data.Seed
{
    public static class Seeder
    {
        private static string animeXmlFilePath =
            @"..\CourseProject.Data\Seed\XML\anime.xml";

        public static IEnumerable<Anime> AnimeSeed()
        {
            XmlSerializer serializer = new(typeof(AnimesList));

            using (StreamReader stream = new(animeXmlFilePath))
            {
                var animesList = serializer.Deserialize(stream) as AnimesList;
                return animesList?.List;
            }
        }
    }
}
