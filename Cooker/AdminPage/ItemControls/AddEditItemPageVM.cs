using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Cooker.AdminPage.GroupControls;
using Cooker.AdminPage.ItemControls;
using Cooker.Models;

namespace Cooker.AdminPage.ItemControls
{
	public partial class AddEditItemPageVM : ObservableObject
	{
		[ObservableProperty]
		public ItemView nItem;

		[ObservableProperty]
		public ImageSource nImage;

		[ObservableProperty]
		public string imagestring;

		[ObservableProperty]
		public List<Group> lGroup;

		[ObservableProperty]
		public Group selectedGroup;

		[ObservableProperty]
		public int index = -1;


		public AddEditItemPageVM()
		{
			loadCommand();
		}
		public async Task loadCommand()
		{
			LGroup =await  GroupFn.GetAll();
			if (ItemFn.ItemAddEdit == 0)
			{
				NItem = new ItemView();
			}
			else
			{
				NItem = await ItemFn.GetItem(ItemFn.ItemAddEdit);
				NImage = NItem.ItmImage;
				SelectedGroup = await GroupFn.GetGroup(NItem.Gid);
				Index = LGroup.IndexOf(SelectedGroup);
			}
		}

		[RelayCommand]
		public async Task SaveAddEdit()
		{
			if (ItemFn.ItemAddEdit == 0)
			{
				if (Imagestring != null)
				{
					NItem.ItmImage = Imagestring;
				}
				NItem.ItmStatus = true;
				await ItemFn.AddAsync(NItem);
			}
			else
			{
				if (Imagestring != null)
				{
					NItem.ItmImage = Imagestring;
				}
				else { 
					NItem.ItmImage = null;
				}

				if (SelectedGroup != null)
				{
					NItem.Gid = SelectedGroup.Id;
				}
				await ItemFn.UpdateAsync(NItem);
			}

			await Shell.Current.GoToAsync("ItemControlPage");
		}
		[RelayCommand]

		public async void Select()
		{
			var result = await FilePicker.PickAsync(new PickOptions
			{
				PickerTitle = "Select Image ",
				FileTypes = FilePickerFileType.Png
			});

			if (result == null)
				return;

			Stream stream = await result.OpenReadAsync();

			NImage = ImageSource.FromStream(() => stream);


			byte[] imageArray = File.ReadAllBytes(result.FullPath);
			Imagestring = Convert.ToBase64String(imageArray);
		}

		[RelayCommand]
		public async void Exit()
		{
			await Shell.Current.GoToAsync("ItemControlPage");

		}
	}
}
