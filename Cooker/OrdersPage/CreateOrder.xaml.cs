namespace Cooker.OrdersPage;

public partial class CreateOrder : ContentPage
{
	private readonly CreateOrderVM createOrderVM;

	public CreateOrder()
	{
		InitializeComponent();
		createOrderVM = new CreateOrderVM();
		BindingContext = createOrderVM;
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await createOrderVM.Reload();
	}
}