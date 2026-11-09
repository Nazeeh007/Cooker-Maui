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
				NImage = NGroup.Gimage;
			}
		}

		[RelayCommand]
		public async Task SaveAddEdit()
		{
			if (GroupFn.GroupAddEdit == 0)
			{
				if (Imagestring != null)
				{
					NGroup.Gimage = Imagestring;
				}
				NGroup.Gstatus = true;
				await GroupFn.AddAsync(NGroup);
			}
			else
			{
				if (Imagestring != null)
				{
					NGroup.Gimage = Imagestring;
				}
				else {
					NGroup.Gimage = null;
				}
					await GroupFn.UpdateAsync(NGroup);
			}

			await Shell.Current.GoToAsync("GroupControlPage");
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
			await Shell.Current.GoToAsync("GroupControlPage");

		}


	}
}

