using System.Windows;
using Prism.Interactivity.InteractionRequest;

namespace WpfTestApp
{
	public interface IDialogService
	{
		/// <summary>ダイアログウィンドウを表示します。</summary>
		InteractionRequest<INotification> DialogRequest { get; }

		MessageBoxResult ShowDialog(INotification notification);
	}
}
