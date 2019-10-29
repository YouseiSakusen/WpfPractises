namespace Prism.Services.Dialogs.Extensions
{
	/// <summary>IDialogService用拡張メソッドクラス。</summary>
	public static class DialogServiceExtensions
	{
		/// <summary>モーダルダイアログを表示します。</summary>
		/// <param name="dlgService">対象のIDialogServiceを表します。</param>
		/// <param name="dialogViewName">表示するダイアログのView名を表す文字列。</param>
		/// <returns>ダイアログの戻り値を表すIDialogResult。</returns>
		public static IDialogResult ShowDialog(this IDialogService dlgService, string dialogViewName)
			=> DialogServiceExtensions.ShowDialog(dlgService, dialogViewName, null);

		/// <summary>モーダルダイアログを表示します。</summary>
		/// <param name="dlgService">対象のIDialogServiceを表します。</param>
		/// <param name="dialogViewName">表示するダイアログのView名を表す文字列。</param>
		/// <param name="parameters">ダイアログに渡すパラメータを表すIDialogParameters。</param>
		/// <returns>ダイアログの戻り値を表すIDialogResult。</returns>
		public static IDialogResult ShowDialog(this IDialogService dlgService, string dialogViewName, IDialogParameters parameters)
		{
			IDialogResult ret = null;

			dlgService.ShowDialog(dialogViewName, parameters, r => ret = r);

			return ret;
		}

		/// <summary>問い合わせメッセーボックスを表示します。</summary>
		/// <param name="dlgService">IDialogService。</param>
		/// <param name="message">表示するメッセージを表す文字列。</param>
		/// <returns>問い合わせメッセーボックスの戻り値を表すButtonResult列挙型の内の1つ。</returns>
		public static ButtonResult ShowConfirmationMessage(this IDialogService dlgService, string message)
		{
			var param = new DialogParameters($"Message={message}");
			var tempRet = ButtonResult.Cancel;

			dlgService.ShowDialog("ConfirmMessageBox", param, r => tempRet = r.Result);

			return tempRet;
		}
	}
}
