using System.Collections.ObjectModel;
using MvvmSampleApp.ClipBoardWatchers;
using MvvmSampleApp.FileWatchers;

namespace MvvmSampleApp
{
	public class SampleAppData : ISampleAppData
	{
		#region プロパティ

		public ObservableCollection<string> WatchedFiles => this.watcher.WatchedFiles;

		public ObservableCollection<int> Stocks => this.clipBoard.Stocks;

		#endregion

		#region メソッド

		public void AddToClipboard(int value)
		{
			this.clipBoard.Add(value);
		}

		#endregion

		#region コンストラクタ

		private FileWatcher watcher = null;

		private ClipBoardStocker clipBoard = null;

		public SampleAppData()
		{
			this.watcher = new FileWatcher();
			this.clipBoard = new ClipBoardStocker();
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
					this.watcher.Dispose();
				}

				// TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
				// TODO: 大きなフィールドを null に設定します。

				disposedValue = true;
			}
		}

		// TODO: 上の Dispose(bool disposing) にアンマネージ リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
		// ~SampleAppData()
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
