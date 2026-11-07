namespace Cooker.OrdersPage;

public partial class SelectTablePage : ContentPage
{
	public SelectTablePage()
	{
		InitializeComponent();
	}
	private void btn1_Clicked(object sender, EventArgs e)
	{
		OrderFn.TableNo = 1;
		Shell.Current.GoToAsync("CreateOrder");
	}

	private void btn7_Clicked(object sender, EventArgs e)
	{
		OrderFn.TableNo = 7;
		Shell.Current.GoToAsync("CreateOrder");
	}

	private void btn2_Clicked(object sender, EventArgs e)
	{
		OrderFn.TableNo = 2;
		Shell.Current.GoToAsync("CreateOrder");
	}

	private void btn5_Clicked(object sender, EventArgs e)
	{
		OrderFn.TableNo = 5;
		Shell.Current.GoToAsync("CreateOrder");
	}

	private void btn8_Clicked(object sender, EventArgs e)
	{
		OrderFn.TableNo = 8;
		Shell.Current.GoToAsync("CreateOrder");
	}

	private void btn3_Clicked(object sender, EventArgs e)
	{
		OrderFn.TableNo = 3;
		Shell.Current.GoToAsync("CreateOrder");
	}

	private void btn9_Clicked(object sender, EventArgs e)
	{
		OrderFn.TableNo = 9;
		Shell.Current.GoToAsync("CreateOrder");
	}

	private void btn6_Clicked(object sender, EventArgs e)
	{
		OrderFn.TableNo = 6;
		Shell.Current.GoToAsync("CreateOrder");
	}


	private void btn4_Clicked(object sender, EventArgs e)
	{
		OrderFn.TableNo = 4;
		Shell.Current.GoToAsync("CreateOrder");
	}
}