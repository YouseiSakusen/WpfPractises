using System;
using System.Reactive.Disposables;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;
using Prism.Services.Dialogs.Extensions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace PrismNetCoreApp
{
	public class PersonalPanelViewModel : BindableBase, IDisposable, IDestructible
	{
		#region コマンド

		public ReactiveCommand ShowPersonDialog { get; }

		private void onShowPersonDialog()
		{
			var ret = this.dialogService.ShowDialog("PersonSelectDialog");
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
		// ~PersonalPanelViewModel()
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

		public void Destroy()
			=> this.Dispose();

		#endregion

		#region コンストラクタ

		private IDialogService dialogService = null;

		private CompositeDisposable disposables = new CompositeDisposable();

		public PersonalPanelViewModel(IDialogService dlgService)
		{
			this.dialogService = dlgService;

			this.ShowPersonDialog = new ReactiveCommand()
				.WithSubscribe(() => this.onShowPersonDialog())
				.AddTo(this.disposables);
		}

		#endregion
	}
}
