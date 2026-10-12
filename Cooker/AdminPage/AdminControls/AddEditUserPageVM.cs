using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Cooker.Models;

namespace Cooker.AdminPage.AdminControls
{
	internal partial class AddEditUserPageVM : ObservableObject
	{

		[ObservableProperty]
		public NewUser nUser;

		[ObservableProperty]
		public List<UserRolesName> lUserRole;

		[ObservableProperty]
		public List<Role> lRole;

		[ObservableProperty]
		public Role selectedRole;


	

		public AddEditUserPageVM()
		{
			loadCommand();
		}
		public async Task loadCommand()
		{
			if (UserFn.UserAddEdit == 0)
			{
				NUser = new NewUser();
				LRole = await UserFn.GetAllRoles();
			}
			else
			{
				NUser = await UserFn.GetUser(UserFn.UserAddEdit);
				LUserRole = await UserFn.GetUserRole(UserFn.UserAddEdit);
				LRole = await UserFn.GetAllRoles();
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

		[RelayCommand]
		public async Task AddRole()
		{
			await UserFn.AddUserRole(UserFn.UserAddEdit, SelectedRole.Id);
			await loadCommand();
		}
		[RelayCommand]
		public async Task DeleteRole(int Id)
		{
			await UserFn.DeleteUserRole(Id);
			await loadCommand();
		}


	}
}


