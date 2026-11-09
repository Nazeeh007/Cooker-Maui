using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Cooker.Models;
using Cooker.OrdersPage;
using Microsoft.AspNetCore.SignalR.Client;

namespace Cooker.AdminPage.OrderControls
{
	public partial class OrderInfoPageVM :ObservableObject
	{


		[ObservableProperty]
		public OrderHeader oHeader;

		[ObservableProperty]
		public List<OrdersView> lOrderView;

		public async Task Reload()
		{
			OHeader = await OrderFn.GetOrderHeader(OrderFn.TableNo);
			LOrderView = await OrderFn.GetAllOrders(OHeader.BillNo);
		}
		[RelayCommand]
		public async void Pay() {
			string result = await OrderFn.TotalOrderPay(OHeader.BillNo);
		}

	}
}
