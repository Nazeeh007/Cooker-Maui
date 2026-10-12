namespace Cooker.AdminPage.AdminControls;

public partial class AdminControlPage : ContentPage
{
	private readonly AdminControlPageVM adminControlPageVM;
	public AdminControlPage()
	{
		InitializeComponent();
		adminControlPageVM = new AdminControlPageVM();
		BindingContext = adminControlPageVM;
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await adminControlPageVM.Reload();
	}
}