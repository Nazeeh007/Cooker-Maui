using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Cooker.Models;
using Newtonsoft.Json;

namespace Cooker.AdminPage.ItemControls
{
	internal class ItemFn
	{
		public static int ItemAddEdit = 0;
		public static async Task<List<Item>> GetAll()
		{
			string result = string.Empty;

			List<Item> LItem = new List<Item>();

			string url = string.Format("https://localhost:7235/Items/GetAllItems");

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);

				HttpResponseMessage response = await client.GetAsync(url);

				if (response.IsSuccessStatusCode)
				{
					result = await response.Content.ReadAsStringAsync();

					LItem = JsonConvert.DeserializeObject<List<Item>>(result);
				}
			}

			return LItem;
		}
		public async static Task<string> AddAsync(Item item)
		{
			string result = string.Empty;

			string url = string.Format($"https://localhost:7235/Items/AddItem");


			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);
				HttpResponseMessage response = await client.PostAsJsonAsync(url, item);

				if (response.IsSuccessStatusCode)
				{
					result = "Ok";
				}
			}
			return result;
		}
		public static async Task<Item> GetItem(int? id)
		{

			string result = string.Empty;

			Item nItem = new Item();


			string url = string.Format($"https://localhost:7235/Items/GetItem?itemId={id}");

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);
				HttpResponseMessage response = await client.GetAsync(url);

				if (response.IsSuccessStatusCode)
				{
					result = await response.Content.ReadAsStringAsync();

					nItem = JsonConvert.DeserializeObject<Item>(result);

				}
			}
			return nItem;
		}
		public static async Task<string> UpdateAsync(Item item)
		{
			string result = string.Empty;
			string url = string.Format($"https://localhost:7235/Items/EditItem");

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);
				HttpResponseMessage response = await client.PostAsJsonAsync(url, item);

				if (response.IsSuccessStatusCode)
				{
					result = "Ok";
				}
			}
			return result;
		}
		public async static Task<string> ChangeStatusAsync(int id, bool Status)
		{
			string result = string.Empty;
			string url = string.Format($"https://localhost:7235/Items/ChangeItemStatus?itemId={id}&status={Status}");


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
	}
}
