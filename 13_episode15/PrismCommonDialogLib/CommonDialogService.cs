using System.Windows;
using Prism.Interactivity.InteractionRequest;

namespace PrismCommonDialog
{
	public class CommonDialogService : ICommonDialogService
	{
		/// <summary>CommonDialog表示用のInteractionRequestを取得します。</summary>
		public InteractionRequest<IConfirmation> CommonDialogRequest { get; }

		/// <summary>コモンダイアログを表示します。</summary>
		/// <param name="confirmation">表示するコモンダイアログの設定内容を表すIConfirmation。</param>
		/// <returns>コモンダイアログの戻り値を表すMessageBoxResult。</returns>
		public MessageBoxResult ShowDialog(IConfirmation confirmation)
		{
			MessageBoxResult result = MessageBoxResult.Cancel;

			this.CommonDialogRequest.Raise(confirmation,
				r => result = r.Confirmed ? MessageBoxResult.OK : MessageBoxResult.Cancel);

			return result;
		}

		/// <summary>コンストラクタ。</summary>
		public CommonDialogService()
		{
			this.CommonDialogRequest = new InteractionRequest<IConfirmation>();
		}
	}
}
