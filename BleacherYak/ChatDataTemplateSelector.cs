using System;

using Xamarin.Forms;

namespace BleacherYak
{
	class MyDataTemplateSelector : Xamarin.Forms.DataTemplateSelector
	{
		public MyDataTemplateSelector()
		{
			// Retain instances!
			this.incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
			this.outgoingDataTemplate = new DataTemplate(typeof(OutViewCell));
		}

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			var messageVm = item as Message;
			if (messageVm == null)
				return null;
			return messageVm.IsIncoming ? this.incomingDataTemplate : this.outgoingDataTemplate;
		}

		private readonly DataTemplate incomingDataTemplate;
		private readonly DataTemplate outgoingDataTemplate;
	}
}