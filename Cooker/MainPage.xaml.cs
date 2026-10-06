namespace Cooker
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

		private async void Button_Clicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("LoginPage");
		}

		private async void OrderBtn_Clicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("CreateOrder");

		}
	}

}
