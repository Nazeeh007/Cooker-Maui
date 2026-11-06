namespace Cooker.AdminPage.OrderControls;

public partial class OrderInfoPage : ContentPage
{

	private readonly OrderInfoPageVM orderInfoPageVM;

	public OrderInfoPage()
	{
		InitializeComponent();
		orderInfoPageVM = new OrderInfoPageVM();
		BindingContext = orderInfoPageVM;
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await orderInfoPageVM.Reload();
	}

}