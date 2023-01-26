﻿namespace Models.Enums
{
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        User, Admin
    }
}
