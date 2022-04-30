using Pandoranime.Resources.Strings;

namespace Pandoranime.ViewModels
{
    public class DiscoverViewModel : BaseViewModel
    {
        private readonly AnimesService _animesService;


        public IEnumerable<AnimeViewModel> _animes ;
        //private CategoriesViewModel categoriesVM;
        private string text;


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
            var animes = await _animesService.GetAnimesAsync(pageIndex);

            if (animes == null)
            {
                await Shell.Current.DisplayAlert(
                    AppResource.Error_Title,
                    AppResource.Error_Message,
                    AppResource.Close);

                return;
            }

            _animes = ConvertToViewModels(animes);
            UpdateAnimes(_animes);
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
