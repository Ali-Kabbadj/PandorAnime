using Pandoranime.Core.AniList;
using Application = Microsoft.Maui.Controls.Application;

namespace Pandoranime
{
    public partial class App : Application
    {
        public static AniClient Client { get; } = new();

        public App()
        {
            InitializeComponent();

            ThemeHelper.SetTheme();

            if (Config.Desktop)
                MainPage = new DesktopShell();
            else
                MainPage = new MobileShell();

            Routing.RegisterRoute(nameof(DiscoverPage), typeof(DiscoverPage));
        }
    }
}