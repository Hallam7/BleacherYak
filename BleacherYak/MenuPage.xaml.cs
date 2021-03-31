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

        async void OpenChat(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ChatPage());
        }
    }
}
