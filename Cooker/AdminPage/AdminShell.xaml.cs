namespace Cooker.AdminPage;

public partial class AdminShell : Shell
{
	public AdminShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("AdminPanel", typeof(AdminPanel));
		Routing.RegisterRoute("AddEditUserPage", typeof(AdminControls.AddEditUserPage));
		Routing.RegisterRoute("AddEditGroupPage", typeof(GroupControls.AddEditGroupPage));
		Routing.RegisterRoute("AddEditItemPage", typeof(ItemControls.AddEditItemPage));
		Routing.RegisterRoute("OrderInfoPage", typeof(OrderControls.OrderInfoPage));



		ShellContent adminControl = new ShellContent();
		ShellContent groupControl = new ShellContent();
		ShellContent ItemControl = new ShellContent();
		ShellContent OrderControl = new ShellContent();
		ShellContent report = new ShellContent();

		adminControl.Title = "Admin Control";
		adminControl.ContentTemplate= new DataTemplate(typeof(AdminControls.AdminControlPage));

		groupControl.Title = "Group Control";
		groupControl.ContentTemplate = new DataTemplate(typeof(GroupControls.GroupControlPage));

		ItemControl.Title = "Item Control";
		ItemControl.ContentTemplate = new DataTemplate(typeof(ItemControls.ItemControlPage));

		OrderControl.Title = "Order Control";
		OrderControl.ContentTemplate = new DataTemplate(typeof(OrderControls.OrderControlPage));

		report.Title = "Report";
		report.ContentTemplate = new DataTemplate(typeof(Report.ReportPage));

		MyAdminShell.Items.Add(adminControl);
		MyAdminShell.Items.Add(groupControl);
		MyAdminShell.Items.Add(ItemControl);
		MyAdminShell.Items.Add(OrderControl);
		MyAdminShell.Items.Add(report);

		Routing.RegisterRoute("AdminControlPage", typeof(AdminControls.AdminControlPage));
		Routing.RegisterRoute("GroupControlPage", typeof(GroupControls.GroupControlPage));
		Routing.RegisterRoute("ItemControlPage", typeof(ItemControls.ItemControlPage));
		Routing.RegisterRoute("OrderControlPage", typeof(OrderControls.OrderControlPage));
		Routing.RegisterRoute("ReportPage", typeof(Report.ReportPage));




	}
}