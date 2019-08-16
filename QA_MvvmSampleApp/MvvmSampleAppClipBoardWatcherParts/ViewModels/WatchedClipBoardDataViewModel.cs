using System;
using System.Reactive.Disposables;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MvvmSampleApp.ClipBoardWatchers.ViewModels
{
	public class WatchedClipBoardDataViewModel : BindableBase, IDisposable
	{
		#region プロパティ

		public ReadOnlyReactivePropertySlim<int> ClipBoardContents { get; }

		#endregion

		#region コンストラクタ

		private int clipBoardValue { get; set; } = 0;
		private CompositeDisposable disposables = new CompositeDisposable();

		public WatchedClipBoardDataViewModel(int value)
		{
			this.clipBoardValue = value;

			this.ClipBoardContents = this.ObserveProperty(x => x.clipBoardValue)
				.ToReadOnlyReactivePropertySlim();
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
