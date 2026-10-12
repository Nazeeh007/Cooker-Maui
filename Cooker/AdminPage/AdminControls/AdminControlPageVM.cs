using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Cooker.Models;

namespace Cooker.AdminPage.AdminControls
{
	partial class AdminControlPageVM : ObservableObject
	{

		[ObservableProperty]
		public List<UserPass> lUserPass;

		public async Task Reload()
		{

			LUserPass = await UserFn.GetAll();
		}

		[RelayCommand]
		public async Task Add()
		{
			UserFn.UserAddEdit = 0;
			await Shell.Current.GoToAsync("AddEditUserPage");
		}

		[RelayCommand]
		public async void Edit(int Id)
		{
			UserFn.UserAddEdit = Id;
			await Shell.Current.GoToAsync("AddEditUserPage");
		}

		[RelayCommand]
		public async void Stop(int Id)
		{
			await UserFn.ChangeStatusAsync(Id, false);
			await Reload();
		}

		[RelayCommand]
		public async void Start(int Id)
		{
			await UserFn.ChangeStatusAsync(Id, true);
			await Reload();
		}
	}
}
