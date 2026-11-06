namespace Cooker.AdminPage;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
	private async void btnlogin_Clicked(object sender, EventArgs e)
	{
		var usrName = Username.Text;
		var password = Password.Text;

		Application.Current.MainPage = new AdminShell();

	}
}