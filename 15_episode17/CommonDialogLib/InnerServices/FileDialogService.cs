using Microsoft.Win32;

namespace WpfPrism72.CommonDialogs.InnerServices
{
	/// <summary>ファイルを開く、ファイルに名前を付けて保存ダイアログ用のサービスを表します。</summary>
	class FileDialogService : ICommonDialogService
	{
		/// <summary>コモンダイアログを表示します。</summary>
		/// <param name="settings">設定情報を表すIDialogSettings。</param>
		/// <returns>trueが返ると選択したファイル名、ユーザがキャンセルするとfalseが返ります。</returns>
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

		/// <summary>表示するコモンダイアログを生成します。</summary>
		/// <param name="settings">設定情報を表すIDialogSettings。</param>
		/// <returns>生成したコモンダイアログを表すFileDialog。</returns>
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

		/// <summary>戻り値を設定します。</summary>
		/// <param name="dialog">表示したダイアログを表すFileDialog。</param>
		/// <param name="settings">設定情報を表すIDialogSettings。</param>
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
