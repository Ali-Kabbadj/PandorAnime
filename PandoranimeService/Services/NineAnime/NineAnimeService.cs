using PandoranimeService.Interfaces.NineAnime;
using PandoranimeService.Models._9Anime;
using PandoranimeService.Services.Scappers;

namespace PandoranimeService.Services.NineAnime
{
    public class NineAnimeService : INineAnimeService
    {
        public async Task<List<AnimeByPageModel>> GetAnimesByPage(int pageIndex)
        {
            if (pageIndex <1)
                pageIndex = 1;
            return await HtmlAgilityPackService.NineAnimeGetListByPageId(pageIndex);
        }

        public async Task<int> GetMaxPage()
        {
            return await PuppeteerSharpService.NineAnimeGetMaxPage();
        }
    }
}
