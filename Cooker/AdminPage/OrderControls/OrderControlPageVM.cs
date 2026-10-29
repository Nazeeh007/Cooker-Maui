using CommunityToolkit.Mvvm.ComponentModel;
using Cooker.AdminPage.GroupControls;
using Cooker.Models;

namespace Cooker.AdminPage.OrderControls
{
	public partial  class OrderControlPageVM: ObservableObject
	{
		[ObservableProperty]
		public List<Group> lGroups;

		public async Task Reload()
		{
			LGroups = await GroupFn.GetAll();
		}
	}
}
