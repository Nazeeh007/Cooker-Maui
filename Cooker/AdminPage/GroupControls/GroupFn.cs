using System.Net.Http.Json;
using System.Text;
using Cooker.Models;
using Newtonsoft.Json;

namespace Cooker.AdminPage.GroupControls
{
	internal class GroupFn
	{
		public static int GroupAddEdit = 0;
		public static async Task<List<Group>> GetAll()
		{
			string result = string.Empty;

			List<Group> LGroups = new List<Group>();

			string url = string.Format("https://localhost:7235/Groups/GetAllGroups");

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);

				HttpResponseMessage response = await client.GetAsync(url);

				if (response.IsSuccessStatusCode)
				{
					result = await response.Content.ReadAsStringAsync();

					LGroups = JsonConvert.DeserializeObject<List<Group>>(result);
				}
			}

			return LGroups;
		}
		public async static Task<string> AddAsync(Group group)
		{
			string result = string.Empty;

			string url = string.Format($"https://localhost:7235/Groups/AddGroup");


			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);
				HttpResponseMessage response = await client.PostAsJsonAsync(url, group);

				if (response.IsSuccessStatusCode)
				{
					result = "Ok";
				}
			}
			return result;
		}
		public static async Task<Group> GetGroup(int? id)
		{

			string result = string.Empty;

			Group nGroup = new Group();


			string url = string.Format($"https://localhost:7235/Groups/GetGroup?gId={id}");

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);
				HttpResponseMessage response = await client.GetAsync(url);

				if (response.IsSuccessStatusCode)
				{
					result = await response.Content.ReadAsStringAsync();

					nGroup = JsonConvert.DeserializeObject<Group>(result);

				}
			}
			return nGroup;
		}
		public static async Task<string> UpdateAsync(Group group)
		{
			string result = string.Empty;

			string url = string.Format($"https://localhost:7235/Groups/EditGroup");

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);
				HttpResponseMessage response = await client.PostAsJsonAsync(url, group);

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

			string url = string.Format($"https://localhost:7235/Groups/ChangeGroupStatus?groupId={id}&status={Status}");


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
