using Pandoranime.Core.Models;

namespace Pandoranime.Core.Interfaces;

public interface IMangaProvider : IProvider
{

    public bool TryExtractImageUrls(MediaContent content, out string[] urls);

}