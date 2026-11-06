namespace Cooker.OrdersPage;

public partial class MyOrderPage : ContentPage
{
	private readonly MyOrderPageVM myOrderPageVM;

	public MyOrderPage()
	{
		InitializeComponent();
		myOrderPageVM = new MyOrderPageVM();
		BindingContext = myOrderPageVM;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await myOrderPageVM.Reload();
	}
}