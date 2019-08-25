using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace WpfPrism72.CommonDialogs.InnerServices
{
	class FileDialogService : ICommonDialogService
	{
		public bool ShowDialog(IDialogSettings settings)
		{
			var dialog = this.createDialogService(settings);
			if (dialog == null)
				return false;

			var ret = dialog.ShowDialog();
			if (ret.HasValue)
			{
				this.setReturnValues(dialog, settings);
				return ret.Value;
			}
			else
			{
				return false;
			}
		}

		private FileDialog createDialogService(IDialogSettings settings)
		{
			if (settings == null)
				return null;

			FileDialog dialog = null;

			if (settings is OpenFileDialogSettings)
				dialog = new OpenFileDialog();
			else if (settings is SaveFileDialogSettings)
				dialog = new SaveFileDialog(); 
			else
				return null;

			var saveSettings = settings as SaveFileDialogSettings;

			dialog.Filter = saveSettings.Filter;
			dialog.FilterIndex = saveSettings.FilterIndex;
			dialog.InitialDirectory = saveSettings.InitialDirectory;
			dialog.Title = saveSettings.Title;

			return dialog;
		}

		private void setReturnValues(FileDialog dialog, IDialogSettings settings)
		{
			if (settings is OpenFileDialogSettings openSettings)
			{
				var openDialog = dialog as OpenFileDialog;

			}
			else if (settings is SaveFileDialogSettings saveSettings)
			{
				var saveDialog = dialog as SaveFileDialog;

			}
		}
	}
}
