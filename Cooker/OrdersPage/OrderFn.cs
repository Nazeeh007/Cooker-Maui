using System.Net.Http.Json;
using Cooker.Models;

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
	}
}
