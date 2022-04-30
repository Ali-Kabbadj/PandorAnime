using PandoranimeService.Services.NineAnime;

namespace Pandoranime.Services
{
    public static class ServicesExtensions
    {
        public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<NineAnimeService>();
            builder.Services.AddSingleton<AnimesService>();

            

            builder.Services.TryAddTransient<WifiOptionsService>();


            return builder;
        }
    }
}
