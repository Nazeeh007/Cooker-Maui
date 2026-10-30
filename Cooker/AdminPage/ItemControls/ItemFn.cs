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
		public static async Task<List<ItemView>> GetAll()
		{
			string result = string.Empty;

			List<ItemView> LItem = new List<ItemView>();

			string url = string.Format("https://localhost:7235/Items/GetAllItems");

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);

				HttpResponseMessage response = await client.GetAsync(url);

				if (response.IsSuccessStatusCode)
				{
					result = await response.Content.ReadAsStringAsync();

					LItem = JsonConvert.DeserializeObject<List<ItemView>>(result);
				}
			}

			return LItem;
		}
		public static async Task<List<ItemView>> GetItemsByGroup(int gID)
		{
			string result = string.Empty;

			List<ItemView> LItem = new List<ItemView>();

			string url = string.Format($"https://localhost:7235/Items/GetAllItemsByGroup?grpId={gID}");

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);

				HttpResponseMessage response = await client.GetAsync(url);

				if (response.IsSuccessStatusCode)
				{
					result = await response.Content.ReadAsStringAsync();

					LItem = JsonConvert.DeserializeObject<List<ItemView>>(result);
				}
			}

			return LItem;
		}
		public async static Task<string> AddAsync(ItemView item)
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
		public static async Task<ItemView> GetItem(int? id)
		{

			string result = string.Empty;

			ItemView nItem = new ItemView();


			string url = string.Format($"https://localhost:7235/Items/GetItem?itemId={id}");

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);
				HttpResponseMessage response = await client.GetAsync(url);

				if (response.IsSuccessStatusCode)
				{
					result = await response.Content.ReadAsStringAsync();

					nItem = JsonConvert.DeserializeObject<ItemView>(result);

				}
			}
			return nItem;
		}
		public static async Task<string> UpdateAsync(ItemView item)
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
