using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WpfPrism72.ViewModels
{
	public class NotificationMessageBoxViewModel : BindableBase, IDialogAware
	{
		public NotificationMessageBoxViewModel()
		{

		}

		public string Title => "メッセージボックスTEST";

		public event Action<IDialogResult> RequestClose;

		public bool CanCloseDialog()
		{
			return true;
		}

		public void OnDialogClosed()
		{
			//throw new NotImplementedException();
		}

		public void OnDialogOpened(IDialogParameters parameters)
		{
			//throw new NotImplementedException();
		}
	}
}
