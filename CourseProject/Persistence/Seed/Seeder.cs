using Models.Entities;
using Models.Enums;
using Persistence.Seed.XML;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace Persistence.Seed
{
    internal static class Seeder
    {
        private static string animeXmlFilePath =
            @"..\Persistence\Seed\XML\anime.xml";

        public static IEnumerable<Anime> AnimeSeed()
        {
            XmlSerializer serializer = new(typeof(AnimesList));

            using (StreamReader stream = new(animeXmlFilePath))
            {
                var animesList = serializer.Deserialize(stream) as AnimesList;
                return animesList?.List;
            }
        }

        public static User UserSeed()
        {
            using (var hmac = new HMACSHA512())
            {
                return new User
                {
                    Username = "Admin",
                    Email = "admin@example.com",
                    Role = Role.Admin,
                    PasswordSalt = hmac.Key,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password"))
                };
            }
        }
    }
}
