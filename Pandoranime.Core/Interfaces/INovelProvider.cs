using Pandoranime.Core.Models;

namespace Pandoranime.Core.Interfaces;

public interface INovelProvider : IProvider
{

    public bool TryExtractText(MediaContent content, out string text);

}