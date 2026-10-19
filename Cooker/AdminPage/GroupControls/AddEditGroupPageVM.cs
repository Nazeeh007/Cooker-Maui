using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Cooker.Models;

namespace Cooker.AdminPage.GroupControls
{
	internal partial class AddEditGroupPageVM : ObservableObject
	{
		[ObservableProperty]
		public Group nGroup;

		[ObservableProperty]
		public ImageSource nImage;

		[ObservableProperty]
		public string imagestring;

		
		public AddEditGroupPageVM()
		{
			loadCommand();
		}
		public async Task loadCommand()
		{
			if (GroupFn.GroupAddEdit == 0)
			{
				NGroup = new Group();
			}
			else
			{
				NGroup = await GroupFn.GetGroup(GroupFn.GroupAddEdit);

			}
		}

		[RelayCommand]
		public async Task SaveAddEdit()
		{
			if (GroupFn.GroupAddEdit == 0)
			{
				NGroup.Gstatus = true;
				await GroupFn.AddAsync(NGroup);
			}
			else
			{
				await GroupFn.UpdateAsync(NGroup);
			}

			await Shell.Current.GoToAsync("GroupControlPage");
		}



	}
}

