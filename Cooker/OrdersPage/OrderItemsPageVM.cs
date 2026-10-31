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
		public int itemCount =0;
		[ObservableProperty]
		public int totalOrder =0;

		public async Task Reload()
		{
			LItem = await ItemFn.GetItemsByGroup(OrderFn.SelectedGroupId);
		}
		[RelayCommand]
		public async Task Select(ItemView itemView)
		{
			NewOrder newOrder = new NewOrder();
			newOrder.OrderBillNo = 1;
			newOrder.OrderTableNo = 1;
			newOrder.ItmId = itemView.Expr1;

			OrderFn.AddAsync(newOrder);
			ItemCount++;

		}
	}
}
