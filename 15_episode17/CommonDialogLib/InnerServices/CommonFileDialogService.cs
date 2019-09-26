using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace WpfPrism72.CommonDialogs.InnerServices
{
	/// <summary>Windows API Code PackのCommonFileDialogを表示します。</summary>
	class CommonFileDialogService : ICommonDialogService
	{
		/// <summary>コモンダイアログを表示します。</summary>
		/// <param name="settings">設定情報を表すIDialogSettings。</param>
		/// <returns>trueが返ると選択したファイル名、ユーザがキャンセルするとfalseが返ります。</returns>
		public bool ShowDialog(ICommonDialogSettings settings)
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
					this.setReturnValues(dialog, settings);
					return true;
			}

			return false;
		}

		/// <summary>表示するコモンダイアログを生成します。</summary>
		/// <param name="settings">設定情報を表すIDialogSettings。</param>
		/// <returns>生成したコモンダイアログを表すCommonFileDialog。</returns>
		private CommonFileDialog createDialog(ICommonDialogSettings settings)
		{
			if (settings == null)
				return null;

			CommonFileDialog dialog = null;

			switch (settings)
			{
				case ApiPackFolderBrowsDialogSettings f:
					dialog = new CommonOpenFileDialog() { IsFolderPicker = true };
					break;
				case ApiPackOpenFileDialogSettings o:
					dialog = new CommonOpenFileDialog();
					break;
				case ApiPackSaveFileDialogSettings s:
					dialog = new CommonSaveFileDialog();
					break;
				default:
					return null;
			}
			
			dialog.InitialDirectory = settings.InitialDirectory;
			dialog.Title = settings.Title;

			var filters = new List<CommonFileDialogFilter>();

			switch (settings)
			{
				case ApiPackOpenFileDialogSettings f:
					filters = ApiPackDialogFilterCreator.Create(f.Filter);
					break;
				case ApiPackSaveFileDialogSettings s:
					filters = ApiPackDialogFilterCreator.Create(s.Filter);
					break;
				default:
					return dialog;
			}

			filters.ForEach(f => dialog.Filters.Add(f));

			return dialog;
		}

		/// <summary>戻り値を設定します。</summary>
		/// <param name="dialog">表示したダイアログを表すFileDialog。</param>
		/// <param name="settings">設定情報を表すIDialogSettings。</param>
		private void setReturnValues(CommonFileDialog dialog, ICommonDialogSettings settings)
		{
			switch (settings)
			{
				case ApiPackOpenFileDialogSettings o:
					o.FileName = dialog.FileName;
					o.FileNames = (dialog as CommonOpenFileDialog)?.FileNames.ToList();
					break;
				case ApiPackSaveFileDialogSettings s:
					s.FileName = dialog.FileName;
					break;
				case ApiPackFolderBrowsDialogSettings f:
					f.SelectedFolderPath = dialog.FileName;
					break;
				default:
					break;
			}
		}
	}
}
