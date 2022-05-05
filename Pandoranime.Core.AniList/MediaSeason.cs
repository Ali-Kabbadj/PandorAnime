using System.Runtime.Serialization;

namespace Pandoranime.Core.AniList;

public enum MediaSeason
{

    [EnumMember(Value = "WINTER")] Winter,
    [EnumMember(Value = "SPRING")] Spring,
    [EnumMember(Value = "SUMMER")] Summer,
    [EnumMember(Value = "FALL")] Fall

}