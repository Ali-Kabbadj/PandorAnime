using System.Runtime.Serialization;

namespace Pandoranime.Core.AniList;

public enum MediaType
{

    [EnumMember(Value = "ANIME")] Anime,
    [EnumMember(Value = "MANGA")] Manga

}