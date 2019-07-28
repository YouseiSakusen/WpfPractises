using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using WpfPrism72.Extensions;

namespace WpfPrism72.ViewModels
{
	/// <summary>ShellのViewModelを表します。</summary>
	public class MainWindowViewModel : BindableBase
	{
		#region "プロパティ"

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

		#region "コマンド"

		/// <summary>OKボタンのCommandを取得します。</summary>
		public ReactiveCommand OkButtonCommand { get; } = new ReactiveCommand();

		#endregion

		#region "メソッド"

		///// <summary>OKボタンのみのメッセージボックスを表示します。</summary>
		///// <param name="message">表示するメッセージを表す文字列。</param>
		///// <returns>メッセージボックスの戻り値を表すButtonResult列挙型の内の1つ。</returns>
		//private ButtonResult showInformationMessage(string message)
		//{
		//	var ret = ButtonResult.Cancel;
		//	var param = new DialogParameters($"Message={message}");

		//	//param.Add("Message", message);
		//	this.dlgService.ShowDialog("NotifiedMessageBox", param, r => ret = r.Result);

		//	return ret;
		//}

		/// <summary>OKボタンのClickイベントハンドラ。</summary>
		private void onOkCommand()
		{
			this.dlgService.ShowInformationMessage("通知メッセージを表示するよ！");
			this.DialogMessage.Value = "OKボタンが押されたよ！";

			//if (this.showInformationMessage("通知メッセージを表示するよ！") == ButtonResult.OK)
			//{
			//	this.DialogMessage.Value = "OKボタンが押されたよ！";
			//}
		}

		#endregion

		#region "コンストラクタ"

		/// <summary>ダイアログ表示サービスを表します。</summary>
		private IDialogService dlgService = null;

		/// <summary>コンストラクタ。</summary>
		/// <param name="dialogService">Prismのダイアログサービスを表すIDialogService。</param>
		public MainWindowViewModel(IDialogService dialogService)
		{
			this.dlgService = dialogService;

			this.OkButtonCommand.Subscribe(this.onOkCommand);
			this.DialogMessage = new ReactivePropertySlim<string>(string.Empty);
		}

		#endregion
	}
}