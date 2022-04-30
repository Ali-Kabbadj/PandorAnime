namespace Pandoranime.Services
{
    public class WifiOptionsService
    {
       

        public async Task<bool> HasWifiOrCanPlayWithOutWifiAsync()
        {

            if (Config.Desktop)
            {
                return true;
            }

            var canPlayMusic = false;
            var current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Not internet", "Check your connection", "close");
            }
            else
            {
                var profiles = Connectivity.ConnectionProfiles;
                var hasWifi = profiles.Contains(ConnectionProfile.WiFi);

                if (!Settings.IsWifiOnlyEnabled || hasWifi)
                {
                    canPlayMusic = true;
                }
                else
                {
                    await Shell.Current.DisplayAlert("You need wifi", "Go to Settings to desactivate this option", "close");
                }
            }

            return canPlayMusic;
        }
    }
}
