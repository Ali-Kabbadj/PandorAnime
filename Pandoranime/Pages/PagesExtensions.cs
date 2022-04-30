
namespace Pandoranime.Pages
{
    public static class PagesExtensions
    {
        public static MauiAppBuilder ConfigurePages(this MauiAppBuilder builder)
        {
            // main tabs of the app
            builder.Services.AddSingleton<DiscoverPage>();

            // pages that are navigated to

            return builder;
        }
    }
}
