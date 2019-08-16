using System;
using System.Reactive.Disposables;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MvvmSampleApp.ViewModels
{
	public class MainWindowViewModel : BindableBase, IDisposable
	{
		#region プロパティ

		private string _title = "Prism Application";
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		#endregion

		#region コマンド

		public ReactiveCommand ClosedCommand { get; }

		public ReactiveCommand ClipBoardCommand { get; }

		#endregion

		#region コンストラクタ

		private ISampleAppData appData = null;
		private IRegionManager regionManager = null;
		private int seqCount = 0;
		private CompositeDisposable disposables = new CompositeDisposable();

		public MainWindowViewModel(ISampleAppData sampleAppData, IRegionManager regionMan)
		{
			this.regionManager = regionMan;
			this.appData = sampleAppData;

			this.ClipBoardCommand = new ReactiveCommand()
				.WithSubscribe(() =>
				{
					this.seqCount++;
					this.appData.AddToClipboard(this.seqCount);
				})
				.AddTo(this.disposables);

			this.ClosedCommand = new ReactiveCommand()
				.WithSubscribe(() => this.Dispose())
				.AddTo(this.disposables);

			this.appData.Stocks.CollectionChanged += (s, e) => this.regionManager.RequestNavigate("ContentRegion", "ClipBoardWatcherView");
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
					this.appData.Dispose();
					this.disposables.Dispose();
				}

				// TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
				// TODO: 大きなフィールドを null に設定します。

				disposedValue = true;
			}
		}

		// TODO: 上の Dispose(bool disposing) にアンマネージ リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
		// ~MainWindowViewModel()
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
	}
}
