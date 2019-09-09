namespace WpfPrism72.CommonDialogs
{
	/// <summary>コモンダイアログ表示用インタフェース</summary>
	public interface ICommonDialogService
	{
		/// <summary>コモンダイアログを表示します。</summary>
		/// <param name="settings">ダイアログと値を受け渡しするためのICommonDialogSettings。</param>
		/// <returns>trueが返るとOKボタン、falseが返るとキャンセルボタンが押されたことを表します。</returns>
		bool ShowDialog(ICommonDialogSettings settings);
	}
}
