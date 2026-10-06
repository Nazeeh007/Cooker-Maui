namespace Cooker.AdminPage;

public partial class AdminShell : Shell
{
	public AdminShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("AdminPanel", typeof(AdminPanel));

	}
}