using Prism.Mvvm;
using Prism.Interactivity.InteractionRequest;

namespace WpfTestApp.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		private string _title = "Prism Application";
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		/// <summary>メッセージボックス表示Messanger</summary>
		public InteractionRequest<INotification> MessageBoxRequest { get; }

		/// <summary>コンストラクタ。</summary>
		/// <param name="msgService">IMessageBoxService。（Unityからインジェクション）</param>
		public MainWindowViewModel(IMessageBoxService msgService)
		{
			this.MessageBoxRequest = msgService.MessageBoxRequest;
		}
	}
}
