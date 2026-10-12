namespace Cooker.AdminPage.AdminControls;

public partial class AddEditUserPage : ContentPage
{
	private readonly AddEditUserPageVM addEditUserPageVM;

	public AddEditUserPage()
	{
		InitializeComponent();
		addEditUserPageVM = new AddEditUserPageVM();
		BindingContext = addEditUserPageVM;
	}
}