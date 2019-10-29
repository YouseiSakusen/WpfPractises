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
	}
}
