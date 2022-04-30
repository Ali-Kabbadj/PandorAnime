namespace Pandoranime.Views;

public partial class AnimeItemView
{

    public static readonly BindableProperty SubscriptionCommandProperty =
        BindableProperty.Create(
            nameof(SubscriptionCommand),
            typeof(ICommand),
            typeof(AnimeItemView),
            default(string));

    public static readonly BindableProperty SubscriptionCommandParameterProperty =
        BindableProperty.Create(
            nameof(SubscriptionCommandParameter),
            typeof(AnimeItemView),
            typeof(AnimeItemView),
            default(AnimeItemView));

    public ICommand SubscriptionCommand
    {
        get { return (ICommand)GetValue(SubscriptionCommandProperty); }
        set { SetValue(SubscriptionCommandProperty, value); }
    }

    public AnimeItemView SubscriptionCommandParameter
    {
        get { return (AnimeItemView)GetValue(SubscriptionCommandParameterProperty); }
        set { SetValue(SubscriptionCommandParameterProperty, value); }
    }


    public AnimeItemView()
	{
		InitializeComponent();
	}
}