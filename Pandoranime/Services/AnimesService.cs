using PandoranimeService.Services.NineAnime;

namespace Pandoranime.Services
{
    public class AnimesService
    {
        private readonly NineAnimeService _nineAnimeService;
        private bool firstLoad = true;
        private int pageIndex = 1;

        public AnimesService()
        {
            _nineAnimeService = new NineAnimeService();
        }

        public Task<IEnumerable<Anime>> GetAnimesAsync()
        {
            return SearchAnimesAsync();
        }

        public async Task<IEnumerable<Anime>> SearchAnimesAsync()
        {
            var animesResponse = await TryGetAsync();

            return animesResponse?.Select(response => GetAnime(response));
        }

        private Anime GetAnime (Anime anime)
        {
            return new Anime() { ImageUrl = anime.ImageUrl,Name = anime.Name, Url= anime.Url};
        }

        private async Task<List<Anime>> TryGetAsync()
        {
           
            var NineAnimes = await _nineAnimeService.GetAnimesByPage(pageIndex);
            var response = new List<Anime>(Anime.ServiceListModelListToModel(NineAnimes));
            return response;
        }

        
    }
}
