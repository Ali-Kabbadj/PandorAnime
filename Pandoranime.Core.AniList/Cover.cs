using Newtonsoft.Json;
using Pandoranime.Core.Helpers;
using Pandoranime.Core.Utils;
using Color = System.Drawing.Color;

namespace Pandoranime.Core.AniList;

public class Cover : Image
{

    [JsonProperty("color")] private readonly string? _colorHex;

    internal static GqlSelection[] Selections =>
        Image.Selections.Concat(new GqlSelection[]
        {
            new("extraLarge"),
            new("color")
        }).ToArray();

    public Color? Color => Utilities.ParseColorHex(_colorHex);

    [JsonProperty("extraLarge")] public string ExtraLargeImageUrl { get; init; }

}