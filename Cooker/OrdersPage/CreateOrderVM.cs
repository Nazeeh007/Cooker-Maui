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

		public async Task Reload()
		{
			LGroups = await GroupFn.GetAll();
		}
		[RelayCommand]
		public async Task Select(Group group)
		{
			OrderFn.SelectedGroupId = group.Id;
			await Shell.Current.GoToAsync("OrderItemsPage");
		}
	}
}
