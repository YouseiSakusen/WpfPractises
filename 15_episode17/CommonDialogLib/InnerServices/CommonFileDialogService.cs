using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace WpfPrism72.CommonDialogs.InnerServices
{
	class CommonFileDialogService : ICommonDialogService
	{
		public bool ShowDialog(IDialogSettings settings)
		{
			var dialog = this.createDialog(settings);
			if (dialog == null)
				return false;

			var ret = dialog.ShowDialog();

			switch (ret)
			{
				case CommonFileDialogResult.None:
				case CommonFileDialogResult.Cancel:
					break;
				case CommonFileDialogResult.Ok:
					return true;
			}

			return false;
		}

		private CommonFileDialog createDialog(IDialogSettings settings)
		{
			if (settings == null)
				return null;

			CommonFileDialog dialog = null;

			if (settings is ApiPackFolderBrowsDialogSettings)
				dialog = new CommonOpenFileDialog() { IsFolderPicker = true };
			if (settings is ApiPackOpenFileDialogSettings)
				dialog = new CommonOpenFileDialog();
			else if (settings is ApiPackSaveFileDialogSettings)
				dialog = new CommonSaveFileDialog();

			if (settings is ApiPackFolderBrowsDialogSettings)
			{
				var openFolderSettings = settings as ApiPackFolderBrowsDialogSettings;

				dialog.InitialDirectory = openFolderSettings.InitialDirectory;
			}
			else
			{
				var saveSettings = settings as ApiPackSaveFileDialogSettings;

				dialog.InitialDirectory = saveSettings.InitialDirectory;
			}

			return dialog;
		}
	}
}
