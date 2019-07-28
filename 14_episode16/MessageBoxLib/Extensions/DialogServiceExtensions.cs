using Prism.Services.Dialogs;

namespace WpfPrism72.Extensions
{
	/// <summary>
	/// IDialogServiceの拡張メソッド。
	/// </summary>
	public static class DialogServiceExtensions
	{
		/// <summary>
		/// 通知メッセーボックスを表示します。
		/// </summary>
		/// <param name="dlgService">IDialogService。</param>
		/// <param name="message">表示するメッセージを表す文字列。</param>
		/// <returns></returns>
		public static void ShowInformationMessage(this IDialogService dlgService, string message)
		{
			var param = new DialogParameters($"Message={message}");
			//var tempRet = ButtonResult.Cancel;

			//param.Add("Message", message);
			dlgService.ShowDialog("NotifiedMessageBox", param, null);
		}
	}
}
