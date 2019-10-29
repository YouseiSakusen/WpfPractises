using System;
using System.Reactive.Disposables;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace PrismNetCoreApp.MessageBoxes
{
	public class ConfirmMessageBoxViewModel : BindableBase, IDialogAware, IDisposable
	{
		#region プロパティ

		/// <summary>メッセージボックスへ表示する文字列を取得します。</summary>
		public ReactivePropertySlim<string> Message { get; }

		#endregion

		#region コマンドとイベント

		public ReactiveCommand YesCommand { get; }

		public ReactiveCommand NoCommand { get; }

		public event Action<IDialogResult> RequestClose;

		#endregion

		#region メソッド

		public string Title
			=> "問い合わせ";

		public bool CanCloseDialog()
			=> true;

		public void OnDialogClosed()
			=> this.Dispose();

		public void OnDialogOpened(IDialogParameters parameters)
		{
			this.Message.Value = parameters.GetValue<string>("Message");
		}

		#endregion

		#region IDisposable Support

		private bool disposedValue = false; // 重複する呼び出しを検出するには

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					this.disposables.Dispose();
				}

				// TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
				// TODO: 大きなフィールドを null に設定します。

				disposedValue = true;
			}
		}

		// TODO: 上の Dispose(bool disposing) にアンマネージ リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
		// ~ConfirmMessageBoxViewModel()
		// {
		//   // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
		//   Dispose(false);
		// }

		// このコードは、破棄可能なパターンを正しく実装できるように追加されました。
		public void Dispose()
		{
			// このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
			Dispose(true);
			// TODO: 上のファイナライザーがオーバーライドされる場合は、次の行のコメントを解除してください。
			// GC.SuppressFinalize(this);
		}

		#endregion

		#region コンストラクタ

		private CompositeDisposable disposables = new CompositeDisposable();

		public ConfirmMessageBoxViewModel()
		{
			this.Message = new ReactivePropertySlim<string>(string.Empty)
				.AddTo(this.disposables);
			this.YesCommand = new ReactiveCommand()
				.WithSubscribe(() => this.RequestClose?.Invoke(new DialogResult(ButtonResult.Yes)))
				.AddTo(this.disposables);
			this.NoCommand = new ReactiveCommand()
				.WithSubscribe(() => this.RequestClose?.Invoke(new DialogResult(ButtonResult.No)))
				.AddTo(this.disposables);
		}

		#endregion
	}
}
