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

		[ObservableProperty]
		public int tableNo;

		public async Task Reload()														 
		{
			TableNo = OrderFn.TableNo;
			OHeader = await OrderFn.GetOrderHeader(TableNo);
			LOrderView = await OrderFn.GetAllOrders(OHeader.BillNo);
		}
		[RelayCommand]
		public async Task ConfirmOrder()
		{
			await OrderFn.ConfirmOrder(OHeader.BillNo);
			await Shell.Current.GoToAsync("SelectTablePage");
		}
	}
}
