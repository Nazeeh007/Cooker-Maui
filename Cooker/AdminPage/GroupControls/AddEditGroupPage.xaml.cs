namespace Cooker.AdminPage.GroupControls;

public partial class AddEditGroupPage : ContentPage
{
	private readonly AddEditGroupPageVM addEditgroupVM;
	public AddEditGroupPage()
	{
		InitializeComponent();
		addEditgroupVM = new AddEditGroupPageVM();
		BindingContext = addEditgroupVM;
	}
}