namespace Cooker.OrdersPage;

public partial class OrderItemsPage : ContentPage
{
	private readonly OrderItemsPageVM orderItemsPageVM;
	public OrderItemsPage()
	{
		InitializeComponent();
		orderItemsPageVM = new OrderItemsPageVM();
		BindingContext = orderItemsPageVM;
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await orderItemsPageVM.Reload();
	}
}