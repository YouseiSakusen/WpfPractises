using System;
using System.Collections.ObjectModel;
using System.IO;

namespace MvvmSampleApp.FileWatchers
{
	class FileWatcher : IDisposable
	{
		#region プロパティ

		public ObservableCollection<string> WatchedFiles { get; } = new ObservableCollection<string>();

		#endregion

		#region イベント

		private void watcherChanged(object sender, FileSystemEventArgs e) => this.WatchedFiles.Add(e.FullPath);

		#endregion

		#region コンストラクタ

		private FileSystemWatcher watcher = null;

		public FileWatcher()
		{
			this.watcher = new FileSystemWatcher
			{
				Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
				NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastWrite | NotifyFilters.LastAccess,
				IncludeSubdirectories = false,
				EnableRaisingEvents = true
			};

			this.watcher.Created += this.watcherChanged;
			this.watcher.Changed += this.watcherChanged;
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
					this.watcher.Created -= this.watcherChanged;
					this.watcher.Changed -= this.watcherChanged;
					this.watcher.Dispose();
				}

				// TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
				// TODO: 大きなフィールドを null に設定します。

				disposedValue = true;
			}
		}

		// TODO: 上の Dispose(bool disposing) にアンマネージ リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
		// ~FileWatcher()
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
