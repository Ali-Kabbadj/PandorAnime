namespace Pandoranime.Pages;

public partial class DesktopShell 
{
	public DesktopShell()
	{
		InitializeComponent();
		BindingContext = new ShellViewModel();
	}
}