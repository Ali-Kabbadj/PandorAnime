using Newtonsoft.Json;
using Pandoranime.Core.Helpers;

namespace Pandoranime.Core.AniList;

public class Name
{

    internal static GqlSelection[] Selections =>
        new GqlSelection[]
        {
            new("full"),
            new("native"),
            new("userPreferred")
        };

    [JsonProperty("full")] public string Romaji { get; init; }
    [JsonProperty("native")] public string? Native { get; init; }
    [JsonProperty("userPreferred")] public string Preferred { get; init; }

}