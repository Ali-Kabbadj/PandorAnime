namespace Pandoranime.ViewModels
{
    public class AnimeViewModel
    {
        public Anime Anime { get; set; } = new Anime();


        public string Name { get => Anime.Name; }

        public string Url { get => Anime.Url; }

        public String Image { get => Anime.ImageUrl; }

        public AnimeViewModel(Anime anime)
        {
            Anime = new Anime(anime.Name,anime.Url,anime.ImageUrl);
        }

        internal Task InitializeAsync()
        {
            return Task.CompletedTask;
        }


        public ICommand NavigateToDetailCommand => new AsyncCommand(NavigateToDetailCommandExecute);
        private Task NavigateToDetailCommandExecute()
        {
            return default;
        }
    }
}
