using Pandoranime.Resources.Strings;

namespace Pandoranime.ViewModels
{
    public class ShellViewModel
    {
        public AppSection Discover { get; set; }
        public AppSection Animes { get; set; }

        public ShellViewModel()
        {
            Discover = new AppSection() { Title = AppResource.Discover, Icon = "discover.png", IconDark = "discover_dark.png", TargetType = typeof(DiscoverPage) };

            //Subscriptions = new AppSection() { Title = AppResource.Subscriptions, Icon = "subscriptions.png", IconDark = "subscriptions_dark.png", TargetType = typeof(SubscriptionsPage) };
            //ListenLater = new AppSection() { Title = Config.Desktop ? AppResource.Listen_Later : AppResource.Listen_Later_Short, Icon = "clock.png", IconDark = "clock_dark.png", TargetType = typeof(ListenLaterPage) };
            //ListenTogether = new AppSection() { Title = Config.Desktop ? AppResource.Listen_Together : AppResource.Listen_Together_Short, Icon = "listentogether.png", IconDark = "listentogether_dark.png", TargetType = typeof(SettingsPage) };
            //Settings = new AppSection() { Title = AppResource.Settings, Icon = "settings.png", IconDark = "settings_dark.png", TargetType = typeof(SettingsPage) };

            //Animes = new AppSection() { Title = "Animes", Icon = "discover.png", IconDark = "discover_dark.png", TargetType = typeof(AnimesPage) };
        }
    }
}
