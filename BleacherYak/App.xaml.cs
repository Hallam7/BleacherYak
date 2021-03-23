using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BleacherYak
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new string[] { "Shapes_Experimental" });

            InitializeComponent();
            //Root Page:
            MainPage = new NavigationPage(new MenuPage());

            //MainPage = new NavigationPage(new MenuPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
