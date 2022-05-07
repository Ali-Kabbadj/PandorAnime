using Pandoranime.Core.AniList;
using Pandoranime.Resources.Strings;

namespace Pandoranime.ViewModels
{
    public class DiscoverViewModel : BaseViewModel
    {
        private readonly AnimesService _animesService;


        public IEnumerable<AnimeViewModel> _animes ;
        //private CategoriesViewModel categoriesVM;
        private string text;

        public ObservableRangeCollection<PaginationGroup> Group { get; private set; } = new ObservableRangeCollection<PaginationGroup>();
        public ObservableRangeCollection<AnimeGroup> AnimeGroup { get; private set; } = new ObservableRangeCollection<AnimeGroup>();
        public ICommand SearchCommand { get; }

        public ICommand SubscribeCommand => new AsyncCommand<AnimeViewModel>(SubscribeCommandExecute);

        public ICommand SeeAllCategoriesCommand => new AsyncCommand(SeeAllCategoriesCommandExecute);

        public string Text
        {
            get { return text; }
            set
            {
                SetProperty(ref text, value);
            }
        }


        public DiscoverViewModel(AnimesService animes)
        {
            _animesService = animes;
        }

        internal async Task InitializeAsync(int pageIndex)
        {
            await FetchAsync(pageIndex);
        }

        private async Task FetchAsync(int pageIndex)
        {
            //var animes = await _animesService.GetAnimesAsync(pageIndex);

            //if (animes == null)
            //{
            //    await Shell.Current.DisplayAlert(
            //        AppResource.Error_Title,
            //        AppResource.Error_Message,
            //        AppResource.Close);

            //    return;
            //}

            //_animes = ConvertToViewModels(animes);
            //UpdateAnimes(_animes);
            var date = DateTime.Today;
            var day = date.DayOfYear - Convert.ToInt32(DateTime.IsLeapYear(date.Year) && date.DayOfYear > 59);
            var CurrentSeason = day switch
            {
                < 80 or >= 355 => MediaSeason.Winter,
                >= 80 and < 172 => MediaSeason.Spring,
                >= 172 and < 266 => MediaSeason.Summer,
                _ => MediaSeason.Fall
            };

            var popularMedia = await App.Client.SearchMedia(new AniFilter { Sort = MediaSort.Popularity }, new AniPaginationOptions(1, 10));
            var trendingMedia = await App.Client.SearchMedia(new AniFilter { Sort = MediaSort.Trending });
            var favoriteMedia = await App.Client.SearchMedia(new AniFilter { Sort = MediaSort.Favorites });
            var seasonalMedia = await App.Client.GetMediaBySeason(CurrentSeason);

            var popularMediaItems = new List<MediaItemModel>();
            var trendingMediaItems = new List<MediaItemModel>();
            var favoriteMediaItems = new List<MediaItemModel>();
            var seasonalMediaItems = new List<MediaItemModel>();

            foreach (var media in popularMedia.Data)
                popularMediaItems.Add(new MediaItemModel(media));
            foreach (var media in trendingMedia.Data)
                trendingMediaItems.Add(new MediaItemModel(media));
            foreach (var media in favoriteMedia.Data)
                favoriteMediaItems.Add(new MediaItemModel(media));
            foreach (var media in seasonalMedia.Data)
                seasonalMediaItems.Add(new MediaItemModel(media));

            var list = new ObservableRangeCollection<PaginationGroup>
            {
                new PaginationGroup(AppResource.Browse, popularMediaItems),
                new PaginationGroup(AppResource.Browse, trendingMediaItems),
                new PaginationGroup(AppResource.Browse, trendingMediaItems),
                new PaginationGroup(AppResource.Browse, trendingMediaItems)
            };

            Group.ReplaceRange(list);

        }

        private static List<AnimeViewModel> ConvertToViewModels(IEnumerable<Anime> animes)
        {
            var viewmodels = new List<AnimeViewModel>();
            foreach (var anime in animes)
            {
                var animeViewModel = new AnimeViewModel(anime);
                viewmodels.Add(animeViewModel);
            }

            return viewmodels;
        }


        private async Task OnSearchCommandAsync()
        {
            throw new NotImplementedException();
        }

        private async Task SubscribeCommandExecute(AnimeViewModel vm)
        {
            throw new NotImplementedException();
        }

        private Task SeeAllCategoriesCommandExecute()
        {
            throw new NotImplementedException();
        }

        private void UpdateAnimes(IEnumerable<AnimeViewModel> listAnimes)
        {
            var list = new ObservableRangeCollection<AnimeGroup>
            {
                new AnimeGroup(AppResource.Browse, listAnimes.ToList()),
            };

            AnimeGroup.ReplaceRange(list);
        }

    }
}
