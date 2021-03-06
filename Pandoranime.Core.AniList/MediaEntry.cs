using Newtonsoft.Json;
using Pandoranime.Core.Helpers;

namespace Pandoranime.Core.AniList;

public class MediaEntry
{

    internal static GqlSelection[] Selections =>
        new GqlSelection[]
        {
            new("id"),
            new("mediaId"),
            new("status"),
            new("progress"),
            new("media", Media.Selections)
        };

    internal static GqlSelection[] MediaSelections =>
        new GqlSelection[]
        {
            new("id"),
            new("mediaId"),
            new("status"),
            new("progress")
        };

    [JsonProperty("id")] public int Id { get; init; }
    [JsonProperty("mediaId")] public int MediaId { get; init; }
    [JsonProperty("status")] public MediaEntryStatus Status { get; init; }
    [JsonProperty("progress")] public int Progress { get; init; }
    [JsonProperty("media")] public Media? Media { get; init; }

}