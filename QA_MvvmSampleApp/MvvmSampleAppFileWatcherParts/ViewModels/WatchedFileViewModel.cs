using System;
using System.Reactive.Disposables;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MvvmSampleApp.FileWatchers.ViewModels
{
	public class WatchedFileViewModel : BindableBase, IDisposable
	{
		#region プロパティ

		public ReadOnlyReactiveProperty<string> FullPath { get; }

		#endregion

		#region コンストラクタ

		private string filePath { get; set; } = string.Empty;
		private CompositeDisposable disposables = new CompositeDisposable();

		public WatchedFileViewModel(string fileFullPath)
		{
			this.filePath = fileFullPath;

			this.FullPath = this.ObserveProperty(x => x.filePath)
				.ToReadOnlyReactiveProperty()
				.AddTo(this.disposables);
		}

		#endregion

		#region デストラクタ

		public void Dispose()
		{
			this.disposables.Dispose();
		}

		#endregion
	}
}
