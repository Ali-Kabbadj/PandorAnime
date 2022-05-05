using Newtonsoft.Json;
using Pandoranime.Core.Helpers;

namespace Pandoranime.Core.AniList;

public class Image
{

    internal static IList<GqlSelection> Selections =>
        new GqlSelection[]
        {
            new("large"),
            new("medium")
        };

    [JsonProperty("large")] public string LargeImageUrl { get; init; }
    [JsonProperty("medium")] public string MediumImageUrl { get; init; }

}