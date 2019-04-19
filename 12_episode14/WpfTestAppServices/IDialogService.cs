using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Interactivity.InteractionRequest;
using Reactive.Bindings;

namespace WpfTestApp
{
	public interface IDialogService
	{
		/// <summary>ダイアログウィンドウを表示します。</summary>
		InteractionRequest<INotification> DialogRequest { get; }

		MessageBoxResult ShowDialog(INotification notification);
	}
}
