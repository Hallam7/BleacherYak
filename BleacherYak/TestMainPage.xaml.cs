using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BleacherYak
{
    public partial class TestMainPage : ContentPage
    {
        public TestMainPage()
        {
            InitializeComponent();
        }

        async void Button_OnClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserName.Text))
            {
                await DisplayAlert("Easy Chat", "Please enter username", "OK");
                return;
            }

            await Navigation.PushAsync(new TestOldChat(UserName.Text));
        }
    }
}
