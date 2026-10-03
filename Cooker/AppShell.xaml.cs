namespace Cooker
{
    public partial class AppShell : Shell
    {
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute("LoginPage", typeof(LoginPage));
			Routing.RegisterRoute("HomePage", typeof(HomePage));
			Routing.RegisterRoute("AppShell", typeof(AppShell));
		}
	}
}
