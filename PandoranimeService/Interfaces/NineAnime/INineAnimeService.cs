using PandoranimeService.Models._9Anime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoranimeService.Interfaces.NineAnime
{
    public interface INineAnimeService
    {
        Task<List<AnimeByPageModel>> GetAnimesByPage(int pageIndex);
        Task<int> GetMaxPage();
    }
}
