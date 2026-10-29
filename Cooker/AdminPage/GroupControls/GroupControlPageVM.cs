using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
		[RelayCommand]
		public async Task Add()
		{
			GroupFn.GroupAddEdit = 0;
			await Shell.Current.GoToAsync("AddEditGroupPage");
		}

		[RelayCommand]
		public async void Edit(int Id)
		{
			GroupFn.GroupAddEdit = Id;
			await Shell.Current.GoToAsync("AddEditGroupPage");
		}

		[RelayCommand]
		public async void Stop(int Id)
		{
			await GroupFn.ChangeStatusAsync(Id, false);
			await Reload();
		}

		[RelayCommand]
		public async void Start(int Id)
		{
			await GroupFn.ChangeStatusAsync(Id, true);
			await Reload();
		}
	}
}
