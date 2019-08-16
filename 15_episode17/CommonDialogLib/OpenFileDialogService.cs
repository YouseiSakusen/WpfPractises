using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Prism.Ioc;
using Prism.Services.Dialogs;

namespace WpfPrism72.CommonDialog
{
	public class OpenFileDialogService : IOpenFileDialogService
	{
		//public void Show(string name, IDialogParameters parameters, Action<IDialogResult> callback)
		//{
		//	return;
		//}

		private OpenFileDialog dialog = new OpenFileDialog();

		public bool? ShowDialog() => this.dialog.ShowDialog();

		public OpenFileDialogService() : base()
		{

		}
		//public void ShowDialog(string name, IDialogParameters parameters, Action<IDialogResult> callback)
		//{
		//	this.dialog.ShowDialog();
		//}

		//private IContainerExtension containerExtension = null;

		//public OpenFileDialogService(IContainerExtension containerExt) : base()
		//{
		//	this.containerExtension = containerExt;
		//}
	}
}
