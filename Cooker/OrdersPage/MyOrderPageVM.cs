using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Cooker.AdminPage.GroupControls;
using Cooker.Models;

namespace Cooker.OrdersPage
{
	public partial class MyOrderPageVM : ObservableObject
	{
		[ObservableProperty]
		public OrderHeader oHeader;

		[ObservableProperty]
		public List<OrdersView> lOrderView;

		public async Task Reload()
		{
			OHeader = await OrderFn.GetOrderHeader(1);
			LOrderView = await OrderFn.GetAllOrders(1);
		}
		[RelayCommand]
		public async Task ConfirmOrder()
		{
			//await Shell.Current.GoToAsync("CreateOrderPage");
		}
	}
}
