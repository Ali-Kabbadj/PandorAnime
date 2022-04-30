namespace Pandoranime.Models
{
    public class AnimeGroup : List<AnimeViewModel>
    {
        public string Name { get; private set; }

        public AnimeGroup(string name, List<AnimeViewModel> anime) : base(anime)
        {
            Name = name;
        }
    }
}
