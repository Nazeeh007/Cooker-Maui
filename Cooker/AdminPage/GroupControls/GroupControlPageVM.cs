
using CommunityToolkit.Mvvm.ComponentModel;
using Cooker.Models;

namespace Cooker.AdminPage.GroupControls
{
	internal partial class GroupControlPageVM : ObservableObject
	{
		[ObservableProperty]
		public List<Group> lGroups;

		public async Task Reload()
		{
			LGroups = await GroupFn.GetAll();
		}
	}
}
