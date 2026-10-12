
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Cooker.Models;

namespace Cooker.AdminPage.AdminControls
{
	internal partial class AddEditUserPageVM : ObservableObject
	{

		[ObservableProperty]
		public NewUser nUser;

		public AddEditUserPageVM()
		{
			loadCommand();
		}
		public async Task loadCommand()
		{
			if (UserFn.UserAddEdit == 0)
			{
				NUser = new NewUser();
			}
			else
			{
				NUser = await UserFn.GetUser(UserFn.UserAddEdit);
			}
		}
		[RelayCommand]
		public async Task SaveAddEdit()
		{
			if (UserFn.UserAddEdit == 0)
			{
				await UserFn.AddAsync(NUser);
			}
			else
			{

				UserPass userPass = new UserPass();
				userPass.Id = UserFn.UserAddEdit;
				userPass.UserName = NUser.UserName;
				userPass.Pass = NUser.Pass;
				userPass.EmployeeName = NUser.EmployeeName;
				userPass.UserStatus = true;
				await UserFn.UpdateAsync(userPass);
			}


			await Shell.Current.GoToAsync("AdminControlPage");
		}


	}
}


