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

		[ObservableProperty]
		public int tableNo;


		public async Task Reload()
		{
			LItem = await ItemFn.GetItemsByGroup(OrderFn.SelectedGroupId);
			OHeader = await OrderFn.GetOrderHeader(OrderFn.TableNo);
			TableNo = OrderFn.TableNo;

		}
		[RelayCommand]
		public async Task Select(ItemView itemView)
		{
			NewOrder newOrder = new NewOrder();
			newOrder.OrderBillNo = OHeader.BillNo;
			newOrder.OrderTableNo = TableNo;
			newOrder.ItmId = itemView.Expr1;
			await OrderFn.AddAsync(newOrder); 
			OHeader = await OrderFn.GetOrderHeader(TableNo);

		}
		[RelayCommand]
		public async Task OpenOrder()
		{
			await Shell.Current.GoToAsync("MyOrderPage");
		}
	}
}
