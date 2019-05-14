using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrismCommonDialog
{
	public interface ICommonDialogService
	{
		/// <summary>ダイアログウィンドウを表示します。</summary>
		InteractionRequest<IConfirmation> CommonDialogRequest { get; }

		MessageBoxResult ShowDialog(IConfirmation confirmation);
	}
}
