using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Cooker.AdminPage.ItemControls;
using Cooker.Models;

namespace Cooker.OrdersPage
{
	public partial class OrderItemsPageVM : ObservableObject
	{
		[ObservableProperty]
		public List<ItemView> lItem;

		[ObservableProperty]
		public OrderHeader oHeader ;
	

		public async Task Reload()
		{
			LItem = await ItemFn.GetItemsByGroup(OrderFn.SelectedGroupId);
			OHeader = await OrderFn.GetOrderHeader(1);

		}
		[RelayCommand]
		public async Task Select(ItemView itemView)
		{
			NewOrder newOrder = new NewOrder();
			newOrder.OrderBillNo = 1;
			newOrder.OrderTableNo = 1;
			newOrder.ItmId = itemView.Expr1;
			OrderFn.AddAsync(newOrder); 
			OHeader = await OrderFn.GetOrderHeader(1);

		}
		[RelayCommand]
		public async Task OpenOrder()
		{
			await Shell.Current.GoToAsync("MyOrderPage");
		}
	}
}
