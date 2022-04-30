using PandoranimeService.Models._9Anime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandoranime.Models
{
    public class Anime : ObservableObject
    {

        public Anime()
        {
        }

        public Anime(string name, string url, string imageUrl)
        {
            Name = name;
            Url = url;
            ImageUrl = imageUrl;
        }

        public static List<Anime> ServiceListModelListToModel(List<AnimeByPageModel> animes)
        {
            var Animes = new List<Anime>();
            foreach (var anime in animes)
            {
                Animes.Add(new Anime()
                {
                    Name = anime.Name,
                    Url = anime.Url,
                    ImageUrl = anime.ImageUrl,
                });
                
            }
            return Animes;
        }


        public string Name { get; set; }

        public string Url { get; set; }

        public string ImageUrl { get;set; }
    }
}
