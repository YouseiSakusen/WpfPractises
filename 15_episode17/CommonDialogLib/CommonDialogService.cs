using WpfPrism72.CommonDialogs.InnerServices;

namespace WpfPrism72.CommonDialogs
{
	/// <summary>コモンダイアログ表示用サービスクラスを表します。</summary>
	public class CommonDialogService : ICommonDialogService
	{
		/// <summary>コモンダイアログを表示します。</summary>
		/// <param name="settings">ダイアログと値を受け渡しするためのICommonDialogSettings。</param>
		/// <returns>trueが返るとOKボタン、falseが返るとキャンセルボタンが押されたことを表します。</returns>
		public bool ShowDialog(ICommonDialogSettings settings)
		{
			var service = this.createInnerService(settings);
			if (service == null)
				return false;

			return service.ShowDialog(settings);
		}

		/// <summary>表示するコモンダイアログサービスを生成します。</summary>
		/// <param name="settings">ダイアログと値を受け渡しするためのICommonDialogSettings。</param>
		/// <returns>表示するコモンダイアログサービスを表すICommonDialogService。</returns>
		private ICommonDialogService createInnerService(ICommonDialogSettings settings)
		{
			if (settings == null)
				return null;

			switch (settings)
			{
				case ApiPackFolderBrowsDialogSettings f:
				case ApiPackOpenFileDialogSettings o:
				case ApiPackSaveFileDialogSettings s:
					return new CommonFileDialogService();
				case OpenFileDialogSettings o:
				case SaveFileDialogSettings s:
					return new FileDialogService();
				default:
					return null;
			}
		}
	}
}
