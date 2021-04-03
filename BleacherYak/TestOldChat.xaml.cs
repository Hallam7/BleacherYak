using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BleacherYak
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestOldChat : ContentPage
	{
		ChatPageViewModel vm;

		public TestOldChat(string username)
		{
			InitializeComponent();

			BindingContext = vm = new ChatPageViewModel(username);
		}
	}
}