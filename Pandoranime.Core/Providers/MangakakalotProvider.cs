using Pandoranime.Core.Interfaces;
using Pandoranime.Core.Models;
using Pandoranime.Core.Utils;

namespace Pandoranime.Core.Providers;

public class MangakakalotProvider : IMangaProvider
{

    public string ImageUrl => Url + "/themes/home/icons/logo.png";
    public string Name => "Mangakakalot";

    private const string Url = "https://mangakakalot.com";

    public IList<MediaSource> GetSources(string query)
    {
        var htmlDocument = Utilities.HtmlWeb.Load(Url + "/search/story/" + query.Replace(' ', '_'));
        var searchElements = htmlDocument.DocumentNode.SelectNodes("//div[@class='panel_story_list']/div[@class='story_item']");
        if (searchElements is not { Count: > 0 })
            return Array.Empty<MediaSource>();
        var sources = new List<MediaSource>();
        foreach (var searchElement in searchElements)
        {
            var linkElement = searchElement.SelectSingleNode("./a");
            var imageElement = linkElement.SelectSingleNode("./img");
            sources.Add(new MediaSource(
                imageElement.Attributes["src"].Value,
                imageElement.Attributes["alt"].Value,
                linkElement.Attributes["href"].Value));
        }
        return sources;
    }

    public IList<MediaContent> GetContents(MediaSource source)
    {
        var htmlElement = Utilities.HtmlWeb.Load(source.Url);
        var chapterElements = htmlElement.DocumentNode.SelectNodes("//div[@class='panel-story-chapter-list']/ul/li");
        if (chapterElements is not { Count: > 0 })
            return Array.Empty<MediaContent>();
        var contents = new List<MediaContent>();
        foreach (var chapterElement in chapterElements)
        {
            var linkElement = chapterElement.SelectSingleNode("./a");
            contents.Add(new MediaContent(linkElement.InnerText, linkElement.Attributes["href"].Value));
        }
        contents.Reverse();
        return contents;
    }

    public bool TryExtractImageUrls(MediaContent content, out string[] urls)
    {
        urls = Array.Empty<string>();
        return false;
    }

}