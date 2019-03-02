using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Interactivity.InteractionRequest;

namespace WpfTestApp
{
	public class MessageBoxService : IMessageBoxService
	{
		public InteractionRequest<INotification> NotificationRequest { get; set; }

		public void ShowNotificationMessageBox(string message)
		{
			this.ShowNotificationMessageBox(message, "情報");
		}

		public void ShowNotificationMessageBox(string message, string title)
		{
			this.NotificationRequest.Raise(new Notification() { Content = message, Title = title });
		}

		public MessageBoxService()
		{
			this.NotificationRequest = new InteractionRequest<INotification>();
		}
	}
}
