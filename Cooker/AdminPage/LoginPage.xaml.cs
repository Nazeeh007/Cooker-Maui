using Cooker.AdminPage.AdminControls;

namespace Cooker.AdminPage;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
	private async void btnlogin_Clicked(object sender, EventArgs e)
	{
		UserFn.UserID = await UserFn.Login(Username.Text, Password.Text);
		if (UserFn.UserID > 0) { 
			Application.Current.MainPage = new AdminShell();
		}
	}
}