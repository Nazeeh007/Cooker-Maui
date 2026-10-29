using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Cooker.AdminPage.ItemControls;
using Cooker.Models;

namespace Cooker.AdminPage.ItemControls
{
	public partial class AddEditItemPageVM : ObservableObject
	{
		[ObservableProperty]
		public Item nItem;

		[ObservableProperty]
		public ImageSource nImage;

		[ObservableProperty]
		public string imagestring;


		public AddEditItemPageVM()
		{
			loadCommand();
		}
		public async Task loadCommand()
		{
			if (ItemFn.ItemAddEdit == 0)
			{
				NItem = new Item();
			}
			else
			{
				NItem = await ItemFn.GetItem(ItemFn.ItemAddEdit);
				NImage = NItem.ItmImage;
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

	}
}
