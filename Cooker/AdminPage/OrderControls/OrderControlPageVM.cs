using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Cooker.Models;
using Cooker.OrdersPage;
using Microsoft.AspNetCore.SignalR.Client;

namespace Cooker.AdminPage.OrderControls
{
	public partial  class OrderControlPageVM: ObservableObject
	{
		[ObservableProperty]
		public List<TotalOrder> lTotalOrders;

		private HubConnection _connection;
		public async Task Reload()
		{
			_connection = new HubConnectionBuilder().WithUrl("https://localhost:7235/chat").Build();

			_connection.On<int>("MessageReceived", async (Message) =>
			{
				lTotalOrders = await OrderFn.GetTotalOrders();
			});
			await _connection.StartAsync();
			LTotalOrders = await OrderFn.GetTotalOrders();
		}

		[RelayCommand]
		public async Task Start(int id)
		{
			OrderFn.TableNo = id;
			await Shell.Current.GoToAsync("OrderInfoPage");
		}
	}
}
