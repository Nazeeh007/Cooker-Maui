namespace Cooker.AdminPage.Report;

public partial class ReportPage : ContentPage
{

	private readonly ReportPageVM reportPageVM;

	public ReportPage()
	{
		InitializeComponent();
		reportPageVM = new ReportPageVM();
		BindingContext = reportPageVM;
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await reportPageVM.Reload();
	}
}