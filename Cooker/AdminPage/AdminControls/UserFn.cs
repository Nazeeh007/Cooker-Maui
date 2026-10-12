
using System.Net.Http.Json;
using System.Text;
using Cooker.Models;
using Newtonsoft.Json;

namespace Cooker.AdminPage.AdminControls
{
	public class UserFn
	{
		public static int UserAddEdit = 0;
		public static async Task<List<UserPass>> GetAll()
		{
			string result = string.Empty;

			List<UserPass> LUserPass = new List<UserPass>();

			string url = string.Format("https://localhost:7235/Users/GetAllUsers");

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);

				HttpResponseMessage response = await client.GetAsync(url);

				if (response.IsSuccessStatusCode)
				{
					result = await response.Content.ReadAsStringAsync();

					LUserPass = JsonConvert.DeserializeObject<List<UserPass>>(result);
				}
			}

			return LUserPass;
		}
		public async static Task<string> AddAsync(NewUser Nuser)
		{
			string result = string.Empty;

			string url = string.Format($"https://localhost:7235/Users/AddUser");


			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);
				HttpResponseMessage response = await client.PostAsJsonAsync(url, Nuser);

				if (response.IsSuccessStatusCode)
				{
					result = "Ok";
				}
			}
			return result;
		}
		public static async Task<NewUser> GetUser(int? id)
		{

			string result = string.Empty;

			NewUser Nuser = new NewUser();


			string url = string.Format($"https://localhost:7235/Users/GetUsers?id={id}");

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);
				HttpResponseMessage response = await client.GetAsync(url);

				if (response.IsSuccessStatusCode)
				{
					result = await response.Content.ReadAsStringAsync();

					Nuser = JsonConvert.DeserializeObject<NewUser>(result);

				}
			}
			return Nuser;
		}
		public static async Task<string> UpdateAsync(UserPass userPass)
		{
			string result = string.Empty;

			var data = JsonConvert.SerializeObject(userPass);

			var Content = new StringContent(data, Encoding.UTF8, "application/json");


			string url = string.Format($"https://localhost:7235/Users/EditUser");


			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(url);
				HttpResponseMessage response = await client.PostAsync(url, Content);

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

			string url = string.Format($"https://localhost:7235/Users/ChangeUserStatus?UserId={id}&status={Status}");


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
