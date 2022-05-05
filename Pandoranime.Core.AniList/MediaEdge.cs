using Newtonsoft.Json;
using Pandoranime.Core.Helpers;

namespace Pandoranime.Core.AniList;

public class MediaEdge
{

    internal static GqlSelection[] Selections =>
        new GqlSelection[]
        {
            new("node", Media.Selections),
            new("relationType") { Parameters = { { "version", 2 } } }
        };

    [JsonProperty("node")] public Media Details { get; init; }
    [JsonProperty("relationType")] public MediaRelation Relation { get; init; }

}