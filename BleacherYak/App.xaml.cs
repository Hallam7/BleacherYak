using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.WebSockets;

using Xamarin.Forms;

namespace BleacherYak
{
    public partial class App : Application
    {
        public App()
        {
            //Device.SetFlags(new string[] { "Shapes" });

            InitializeComponent();
            //Root Page:
            MainPage = new NavigationPage(new MenuPage());

            //MainPage = new NavigationPage(new TestMainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}