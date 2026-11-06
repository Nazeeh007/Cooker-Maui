using System.Net.Http.Json;
using Cooker.Models;
using Newtonsoft.Json;

namespace Cooker.OrdersPage
{
	public class OrderFn
	{
		public static int SelectedGroupId;


		public async static Task<string> AddAsync(NewOrder nOrder)
		{
			string result = string.Empty;

			string url = string.Format($"https://localhost:7235/Orders/AddOrder");


			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);
				HttpResponseMessage response = await client.PostAsJsonAsync(url, nOrder);

				if (response.IsSuccessStatusCode)
				{
					result = "Ok";
				}
			}
			return result;
		}

		public static async Task<OrderHeader> GetOrderHeader(int OrderBillId)
		{
			string result = string.Empty;

			OrderHeader orderHeader = new OrderHeader();

			string url = string.Format($"https://localhost:7235/Orders/OrderHeader?orderBillNo={OrderBillId}");

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);

				HttpResponseMessage response = await client.GetAsync(url);

				if (response.IsSuccessStatusCode)
				{
					result = await response.Content.ReadAsStringAsync();

					orderHeader = JsonConvert.DeserializeObject<OrderHeader>(result);
				}
			}

			return orderHeader;
		}

		public static async Task<List<OrdersView>> GetAllOrders(int OrderBillId)
		{
			string result = string.Empty;

			List<OrdersView> lOrderList = new List<OrdersView>();

			string url = string.Format($"https://localhost:7235/Orders/GetOrder?orderBillNo={OrderBillId}");

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);

				HttpResponseMessage response = await client.GetAsync(url);

				if (response.IsSuccessStatusCode)
				{
					result = await response.Content.ReadAsStringAsync();

					lOrderList = JsonConvert.DeserializeObject<List<OrdersView>>(result);
				}
			}

			return lOrderList;
		}
		public static async Task<List<TotalOrder>> GetTotalOrders()
		{
			string result = string.Empty;

			List<TotalOrder> LTotalOrder = new List<TotalOrder>();

			string url = string.Format($"https://localhost:7235/Orders/GetAllOrders");

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);

				HttpResponseMessage response = await client.GetAsync(url);

				if (response.IsSuccessStatusCode)
				{
					result = await response.Content.ReadAsStringAsync();

					LTotalOrder = JsonConvert.DeserializeObject<List<TotalOrder>>(result);
				}
			}

			return LTotalOrder;
		}

		public static async Task<string> TotalOrderPay(int billNo)
		{
			string result = string.Empty;

			string url = string.Format($"https://localhost:7235/Orders/TotalOrderPay?orderBillNo={billNo}");

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);

				HttpResponseMessage response = await client.GetAsync(url);

				if (response.IsSuccessStatusCode)
				{
					result = "Ok";

				}
			}

			return result;
		}		
		public static async Task<List<TotalOrder>> GetAllOrdersReports(string  orderDate)
		{
			string result = string.Empty;

			List<TotalOrder> LTotalOrder = new List<TotalOrder>();

			string url = string.Format($"https://localhost:7235/Orders/GetAllOrdersReports?strOrderDate={orderDate}");

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);

				HttpResponseMessage response = await client.GetAsync(url);

				if (response.IsSuccessStatusCode)
				{
					result = await response.Content.ReadAsStringAsync();

					LTotalOrder = JsonConvert.DeserializeObject<List<TotalOrder>>(result);
				}
			}

			return LTotalOrder;
		}
	}
}
