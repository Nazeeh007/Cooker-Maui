using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Cooker.Models;
using Cooker.OrdersPage;

namespace Cooker.AdminPage.Report
{
	public partial class ReportPageVM : ObservableObject
	{
		[ObservableProperty]
		public DateTime selectedDate;

		[ObservableProperty]
		public List<TotalOrder> lTotalOrder;

		[ObservableProperty]
		public double? lTotal = 0;

		public async Task Reload()
		{
			SelectedDate = DateTime.Now;
			LTotalOrder = await OrderFn.GetAllOrdersReports(SelectedDate.ToString("MM-dd-yyyy"));
			if (LTotalOrder != null) {
				LTotal = LTotalOrder.Sum(i => i.ToTotal);
			}

		}

		[RelayCommand]
		public async Task Search()
		{
			LTotalOrder = await OrderFn.GetAllOrdersReports(SelectedDate.ToString("MM-dd-yyyy"));
			if (LTotalOrder != null)
			{
				LTotal = LTotalOrder.Sum(i => i.ToTotal);
			}

		}
	}
}
