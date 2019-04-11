using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Interactivity.InteractionRequest;
using Reactive.Bindings;

namespace WpfTestApp
{
	public class DialogService : IDialogService
	{
		public InteractionRequest<INotification> DialogRequest { get; }

		public DialogService()
		{
			this.DialogRequest = new InteractionRequest<INotification>();
		}

		public MessageBoxResult ShowDialog(INotification notification)
		{
			var msgRet = MessageBoxResult.Cancel;
			this.DialogRequest.Raise(notification, r =>
			{
				msgRet = (r as IConfirmation).Confirmed ? MessageBoxResult.OK : MessageBoxResult.Cancel;
			});

			return msgRet;
		}
	}
}
