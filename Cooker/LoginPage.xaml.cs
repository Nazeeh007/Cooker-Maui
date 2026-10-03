namespace Cooker;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
	private async void btnlogin_Clicked(object sender, EventArgs e)
	{

		//await Shell.Current.GoToAsync("NewPage1");
		Application.Current.MainPage = new AppShell();

	}
}