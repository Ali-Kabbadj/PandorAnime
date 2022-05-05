using System.Runtime.Serialization;

namespace Pandoranime.Core.AniList;

public enum CharacterRole
{

    [EnumMember(Value = "MAIN")] Main,
    [EnumMember(Value = "SUPPORTING")] Supporting,
    [EnumMember(Value = "BACKGROUND")] Background

}