using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Interactivity.InteractionRequest;

namespace WpfTestApp
{
	public interface IMessageBoxService
	{
		InteractionRequest<INotification> NotificationRequest { get; set; }

		void ShowNotificationMessageBox(string message);

		void ShowNotificationMessageBox(string message, string title);
	}
}
