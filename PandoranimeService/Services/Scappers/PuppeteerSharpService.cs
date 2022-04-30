using PandoranimeService.Models._9Anime;
using PuppeteerSharp;
using System.Text.RegularExpressions;
using Page = PuppeteerSharp.Page;

namespace PandoranimeService.Services.Scappers
{
    public class PuppeteerSharpService
    {
        const string NINE_ANIME_LIST_URL= "https://9anime.to/az-list";

        public static async Task<Page> OpenChromiumPage()
        {

            var browserFetcher = new BrowserFetcher(new BrowserFetcherOptions
            {
                Path = @"C:\\Users\\ALIKA\\OneDrive\\Documents\\PandoranimeFiles"
            });

            await browserFetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                DefaultViewport = ViewPortOptions.Default,
                ExecutablePath = @"C:\\Users\\ALIKA\\OneDrive\\Documents\\PandoranimeFiles\\Win64-970485\\chrome-win\\chrome.exe"
            });

            return await browser.NewPageAsync();
        }

        public static async void CloseChromium(Page page)
        {
            if (!page.IsClosed && page != null)
            {
                await page.Browser.CloseAsync();
            }
        }

        public static async Task<int> NineAnimeGetMaxPage()
        {
            using (var page = await OpenChromiumPage())
            {
                await page.SetJavaScriptEnabledAsync(false);
                await page.GoToAsync(NINE_ANIME_LIST_URL);

                var maxPage = await page.EvaluateExpressionAsync<string>("Array.from(document.querySelectorAll('.pagenav form span'))[3].innerText");

                Regex rgx = new Regex(@"\D");
                maxPage = rgx.Replace(maxPage, "");

                return int.Parse(maxPage);
            }
        }

        public static async Task<List<AnimeByPageModel>> NineAnimeGetListByPageId(int pageId)
        {
            const string ANIME_IMAGE_URL_EXPRETION = "Array.from(document.querySelectorAll('.anime-list-v li .thumb img')).map(img => img.getAttribute('src'))";
            const string ANIME_URL_EXPRETION = "Array.from(document.querySelectorAll('.anime-list-v li .info a')).map(a => a.href)";
            const string ANIME_NAME_EXPRETION = "Array.from(document.querySelectorAll('.anime-list-v li .info a')).map(a => a.text)";

            var Animes = new List<AnimeByPageModel>();

            using (var page = await OpenChromiumPage())
            {                
                WaitUntilNavigation[] waitUntil = new[] { WaitUntilNavigation.Networkidle0, WaitUntilNavigation.Networkidle2, WaitUntilNavigation.DOMContentLoaded, WaitUntilNavigation.Load ,WaitUntilNavigation.DOMContentLoaded};

                await page.SetJavaScriptEnabledAsync(false);
                await page.GoToAsync(NINE_ANIME_LIST_URL, new NavigationOptions { WaitUntil = waitUntil });


                var imageUrls = await page.EvaluateExpressionAsync<string[]>(ANIME_IMAGE_URL_EXPRETION);
                var showUrl = await page.EvaluateExpressionAsync<string[]>(ANIME_URL_EXPRETION);
                var showNames = await page.EvaluateExpressionAsync<string[]>(ANIME_NAME_EXPRETION);
                

                for (int i = 0; i < imageUrls.Length; i++)
                {
                    Animes.Add(new AnimeByPageModel()
                    {
                        Name = showNames[i],
                        Url = showUrl[i],
                        ImageUrl = imageUrls[i]
                    });
                }
            }
            return Animes;
        }



    }
}
