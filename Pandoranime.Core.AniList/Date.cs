using Pandoranime.Core.Helpers;

namespace Pandoranime.Core.AniList;

public class Date
{

    internal static GqlSelection[] Selections =>
        new GqlSelection[]
        {
            new("year"),
            new("month"),
            new("day")
        };

    public int? Year { get; init; }
    public int? Month { get; init; }
    public int? Day { get; init; }

    public DateOnly? ToDateOnly()
    {
        if (!(Year.HasValue && Month.HasValue && Day.HasValue))
            return null;
        return new DateOnly(Year.Value, Month.Value, Day.Value);
    }

}