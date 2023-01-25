using System.Text.Json.Serialization;

namespace Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        User, Admin
    }
}
