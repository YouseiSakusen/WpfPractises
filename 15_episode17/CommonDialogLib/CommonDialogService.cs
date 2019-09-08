using WpfPrism72.CommonDialogs.InnerServices;

namespace WpfPrism72.CommonDialogs
{
	/// <summary>コモンダイアログ表示用サービスクラスを表します。</summary>
	public class CommonDialogService : ICommonDialogService
	{
		public bool ShowDialog(IDialogSettings settings)
		{
			var service = this.createInnerService(settings);
			if (service == null)
				return false;

			return service.ShowDialog(settings);
		}

		private ICommonDialogService createInnerService(IDialogSettings settings)
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
