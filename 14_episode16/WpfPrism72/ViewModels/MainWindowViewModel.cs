using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using WpfPrism72.Extensions;

namespace WpfPrism72.ViewModels
{
	/// <summary>ShellのViewModelを表します。</summary>
	public class MainWindowViewModel : BindableBase
	{
		#region プロパティ

		/// <summary>ダイアログの表示結果を取得します。</summary>
		public ReactivePropertySlim<string> DialogMessage { get; }

		/// <summary>画面のタイトルを取得・設定します。</summary>
		private string _title = "Prism Application";
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		#endregion

		#region コマンド

		/// <summary>OKボタンのCommandを取得します。</summary>
		public ReactiveCommand ShowMessageButtonCommand { get; }

		#endregion

		#region メソッド

		///// <summary>OKボタンのみのメッセージボックスを表示します。</summary>
		///// <param name="message">表示するメッセージを表す文字列。</param>
		///// <returns>メッセージボックスの戻り値を表すButtonResult列挙型の内の1つ。</returns>
		//private ButtonResult showInformationMessage(string message)
		//{
		//	var ret = ButtonResult.No;
		//	var param = new DialogParameters($"Message={message}");

		//	//param.Add("Message", message);
		//	this.dlgService.ShowDialog("ConfirmedMessageBox", param, r => ret = r.Result);

		//	return ret;
		//}

		/// <summary>OKボタンのClickイベントハンドラ。</summary>
		private void onShowMessageButtonCommand()
		{
			//this.dlgService.ShowInformationMessage("通知メッセージを表示するよ！");
			//this.DialogMessage.Value = "OKボタンが押されたよ！";

			if (this.dlgService.ShowConfirmationMessage("通知メッセージを表示するよ！") == ButtonResult.Yes)
				this.DialogMessage.Value = "OKボタンが押されたよ！";
			else
				this.DialogMessage.Value = string.Empty;
		}

		#endregion

		#region コンストラクタ

		/// <summary>ダイアログ表示サービスを表します。</summary>
		private IDialogService dlgService = null;

		/// <summary>コンストラクタ。</summary>
		/// <param name="dialogService">Prismのダイアログサービスを表すIDialogService。</param>
		public MainWindowViewModel(IDialogService dialogService)
		{
			this.dlgService = dialogService;

			this.ShowMessageButtonCommand = new ReactiveCommand()
				.WithSubscribe(this.onShowMessageButtonCommand);
			this.DialogMessage = new ReactivePropertySlim<string>(string.Empty);
		}

		#endregion
	}
}