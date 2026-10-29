namespace Cooker.AdminPage.ItemControls;

public partial class ItemControlPage : ContentPage
{
	private readonly ItemControlPageVM itemControlPageVM;

	public ItemControlPage()
	{
		InitializeComponent();
		itemControlPageVM = new ItemControlPageVM();
		BindingContext = itemControlPageVM;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await itemControlPageVM.Reload();
	}

}