using HtmlAgilityPack;
using PandoranimeService.Models._9Anime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PandoranimeService.Services.Scappers
{
    public class HtmlAgilityPackService
    {
        const string NINE_ANIME_LIST_URL = "https://9anime.to/az-list";

        public static async Task<HtmlDocument> GetHtmlDoc(string url)
        {
            var web = new HtmlWeb();
            var document = await web.LoadFromWebAsync(url);
            return document;
        }

        public static async Task<List<AnimeByPageModel>> NineAnimeGetListByPageId(int pageIndex)
        {
            var document = await GetHtmlDoc(NINE_ANIME_LIST_URL+$"?page={2}");

            var imagesHtml = document.DocumentNode.SelectNodes("//aside[1]/section[1]/div[2]/ul[1]/li//img");
            var titlesAndUrlsHtml = document.DocumentNode.SelectNodes("//aside[1]/section[1]/div[2]/ul[1]/li//a");

            var Animes = new List<AnimeByPageModel>();

            for (int i = 0; i < imagesHtml.Count(); i++)
            {
                string rawText = titlesAndUrlsHtml[i].InnerText.Trim();

                string name = HttpUtility.HtmlDecode(rawText);
                string url = "https://9anime.to" + titlesAndUrlsHtml[i].Attributes["href"].Value;
                string image = imagesHtml[i].Attributes["src"].Value;

                Animes.Add(new AnimeByPageModel()
                {
                    
                    Name = name,
                    Url = url,
                    ImageUrl = image
                });
            }

            return Animes;
        }
    }
}
