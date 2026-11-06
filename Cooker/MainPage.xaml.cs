using Microsoft.AspNetCore.SignalR.Client;

namespace Cooker
{
    public partial class MainPage : ContentPage
    {

		private readonly HubConnection _connection;

		public MainPage()
        {
            InitializeComponent();
			_connection = new HubConnectionBuilder()
					 .WithUrl("https://localhost:7235/chat")
					 .Build();
			_connection.On<string>("MessageReceived", (Message) =>
			{
				var s = Message;
			});

			Task.Run(() => { Dispatcher.Dispatch(async () => await _connection.StartAsync()); });

		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("LoginPage");
		}

		private async void OrderBtn_Clicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("CreateOrder");

		}
		private async void ChatBtn_Clicked(object sender, EventArgs e)
		{
			await _connection.InvokeAsync("SendMessage", "Good");
		}
	}

}
