using Pandoranime.Core.Models;

namespace Pandoranime.Core.Interfaces
{

    public interface IAnimeProvider : IProvider
    {

        public bool TryExtractVideoUrl(MediaContent content, out string url);
        public bool TryExtractVideoPlayerUrl(MediaContent content, out string url);

    }
}