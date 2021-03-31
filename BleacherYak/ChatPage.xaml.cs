using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BleacherYak.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BleacherYak
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        //ChatPageViewModel vm;

        public ChatPage()
        {
            this.BindingContext = new MainViewModel();
            InitializeComponent();
            //BindingContext = vm = new ChatPageViewModel(username);
        }
    }
}
