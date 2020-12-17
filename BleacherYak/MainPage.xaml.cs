using System;
using System.Net.WebSockets;
using System.Threading;
using Xamarin.Forms;

namespace BleacherYak
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		async void Button_OnClicked(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(UserName.Text))
			{
				await DisplayAlert("BleacherYak", "Please enter username", "OK");
				return;
			}

			await Navigation.PushAsync(new ChatPage(UserName.Text));
		}
	}
}