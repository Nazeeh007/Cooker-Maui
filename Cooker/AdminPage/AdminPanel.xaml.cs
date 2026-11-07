using System.Threading.Tasks;
using Cooker.AdminPage.AdminControls;
using Cooker.Models;

namespace Cooker.AdminPage;

public partial class AdminPanel : ContentPage
{
	public AdminPanel()
	{
		InitializeComponent();
		//AdminControl.IsVisible = false;

		
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();

		List<UserRolesName> LUserRoles = new List<UserRolesName>();

		LUserRoles =  await UserFn.GetUserRole(UserFn.UserID);

		//var role1 = LUserRoles.Where(x => x.RoleName == "Admin").FirstOrDefault();
		var Role1 = LUserRoles.Where(i => i.RoleId == 1).Count();
		var Role2 = LUserRoles.Where(i => i.RoleId == 2).Count();
		var Role3 = LUserRoles.Where(i => i.RoleId == 3).Count();
		var Role4 = LUserRoles.Where(i => i.RoleId == 4).Count();

		if (Role1 == 1) AdminControl.IsVisible = true;
		else AdminControl.IsVisible = false;
		if (Role2 == 1)
		{
			GroupControl.IsVisible = true;
			ItemControl.IsVisible = true;
		}
		if (Role3 == 1) OrderControl.IsVisible = true;
		if (Role4 == 1) Report.IsVisible = true;
	}

	private async void AdminControl_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("AdminControlPage");
	}

	private async void ItemControl_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("ItemControlPage");

	}

	private async void OrderControl_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("OrderControlPage");

	}

	private async void Report_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("ReportPage");

	}

	private async void GroupControl_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("GroupControlPage");

	}
}