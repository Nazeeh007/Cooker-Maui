using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Cooker.Models;

namespace Cooker.AdminPage.ItemControls
{
	public partial class ItemControlPageVM : ObservableObject
	{
		[ObservableProperty]
		public List<ItemView> lItems;

		public async Task Reload()
		{
			LItems = await ItemFn.GetAll();
		}
		[RelayCommand]
		public async Task Add()
		{
			ItemFn.ItemAddEdit = 0;
			await Shell.Current.GoToAsync("AddEditItemPage");
		}

		[RelayCommand]
		public async void Edit(int Id)
		{
			ItemFn.ItemAddEdit = Id;
			await Shell.Current.GoToAsync("AddEditItemPage");
		}

		[RelayCommand]
		public async void Stop(int Id)
		{
			await ItemFn.ChangeStatusAsync(Id, false);
			await Reload();
		}

		[RelayCommand]
		public async void Start(int Id)
		{
			await ItemFn.ChangeStatusAsync(Id, true);
			await Reload();
		}
		[RelayCommand]
		public async void Back()
		{
			Application.Current.MainPage = new AdminShell();
		}
	}
}
