using Cooker.AdminPage.GroupControls;

namespace Cooker.AdminPage.ItemControls;

public partial class AddEditItemPage : ContentPage
{
	private readonly AddEditItemPageVM addEditItemVM;

	public AddEditItemPage()
	{
		InitializeComponent();
		addEditItemVM = new AddEditItemPageVM();
		BindingContext = addEditItemVM;
	}
}