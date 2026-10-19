
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
	}
}
