using Newtonsoft.Json;
using Pandoranime.Core.Helpers;

namespace Pandoranime.Core.AniList;

public class CharacterEdge
{

    internal static GqlSelection[] Selections =>
        new GqlSelection[]
        {
            new("node", Character.Selections),
            new("role")
        };

    [JsonProperty("node")] public Character Details { get; init; }
    [JsonProperty("role")] public CharacterRole Role { get; init; }

}