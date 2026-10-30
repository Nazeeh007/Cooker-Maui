using Cooker.OrdersPage;
using Cooker.AdminPage;

namespace Cooker
{
    public partial class AppShell : Shell
    {
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute("LoginPage", typeof(LoginPage));
			Routing.RegisterRoute("CreateOrder", typeof(CreateOrder));
			Routing.RegisterRoute("OrderItemsPage", typeof(OrderItemsPage));
			//Routing.RegisterRoute("AppShell", typeof(AppShell));
			//Routing.RegisterRoute("HomePage", typeof(HomePage));
		}
	}
}
