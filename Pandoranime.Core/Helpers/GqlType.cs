using System.Runtime.Serialization;

namespace Pandoranime.Core.Helpers;

public enum GqlType
{

    [EnumMember(Value = "query")] Query,
    [EnumMember(Value = "mutation")] Mutation

}