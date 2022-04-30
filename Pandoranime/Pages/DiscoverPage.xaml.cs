namespace Pandoranime.Pages;

public partial class DiscoverPage : ContentPage
{
	private DiscoverViewModel ViewModel => BindingContext as DiscoverViewModel;

	public DiscoverPage(DiscoverViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ViewModel.InitializeAsync();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }

    
}