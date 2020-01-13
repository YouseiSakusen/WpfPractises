using System.Windows;
using Prism.Interactivity.InteractionRequest;

namespace PrismCommonDialog
{
	public interface ICommonDialogService
	{
		/// <summary>ダイアログウィンドウを表示します。</summary>
		InteractionRequest<IConfirmation> CommonDialogRequest { get; }

		MessageBoxResult ShowDialog(IConfirmation confirmation);
	}
}
