namespace Pandoranime.ViewModels
{
    public static class ViewModelExtensions
    {
        public static MauiAppBuilder ConfigureViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<DiscoverViewModel>();

            builder.Services.AddSingleton<AnimeViewModel>();

            return builder;
        }
    }
}
