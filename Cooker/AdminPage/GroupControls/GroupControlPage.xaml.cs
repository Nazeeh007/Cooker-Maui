namespace Cooker.AdminPage.GroupControls;

public partial class GroupControlPage : ContentPage
{
	private readonly GroupControlPageVM groupControlVM;

	public GroupControlPage()
	{
		InitializeComponent();
		groupControlVM = new GroupControlPageVM();
		BindingContext = groupControlVM;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await groupControlVM.Reload();
	}

}