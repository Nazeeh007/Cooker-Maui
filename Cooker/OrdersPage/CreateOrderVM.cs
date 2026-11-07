using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Cooker.AdminPage.GroupControls;
using Cooker.Models;

namespace Cooker.OrdersPage
{
	public partial class CreateOrderVM : ObservableObject
	{
		[ObservableProperty]
		public List<Group> lGroups;

		[ObservableProperty]
		public OrderHeader oHeader;

		[ObservableProperty]
		public int tableNo;

		public async Task Reload()
		{
			LGroups = await GroupFn.GetAll();
			OHeader = await OrderFn.GetOrderHeader(OrderFn.TableNo);
			TableNo = OrderFn.TableNo;

		}
		[RelayCommand]
		public async Task Select(Group group)
		{
			OrderFn.SelectedGroupId = group.Id;
			await Shell.Current.GoToAsync("OrderItemsPage");
		}

		[RelayCommand]
		public async Task OpenOrder()
		{
			await Shell.Current.GoToAsync("MyOrderPage");
		}
	}
}
