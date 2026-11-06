using Cooker.AdminPage.GroupControls;

namespace Cooker.AdminPage.OrderControls;

public partial class OrderControlPage : ContentPage
{
	private readonly OrderControlPageVM orderControlPageVM;

	public OrderControlPage()
	{
		InitializeComponent();
		orderControlPageVM = new OrderControlPageVM();
		BindingContext = orderControlPageVM;
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await orderControlPageVM.Reload();
	}
}