namespace Cooker.AdminPage;

public partial class AdminPanel : ContentPage
{
	public AdminPanel()
	{
		InitializeComponent();
		//AdminControl.IsVisible = false;

		
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