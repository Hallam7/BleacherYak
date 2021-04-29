using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BleacherYak
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        async void OpenNBA(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new GameListPage());
        }

        async void OpenNFL(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NFLGamesListPage());
        }

        async void OpenSettings(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        async void OpenChat(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ChatPage());
        }
    }
}
