using System.Reactive.Disposables;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MvvmSampleApp.ClipBoardWatchers.ViewModels
{
	public class ClipBoardWatcherViewViewModel : BindableBase, IDestructible
	{
		#region プロパティ

		public ReadOnlyReactiveCollection<WatchedClipBoardDataViewModel> ClipBoardDatas { get; }

		#endregion

		#region コンストラクタ

		private ISampleAppData appData = null;
		private CompositeDisposable disposables = new CompositeDisposable();

		public ClipBoardWatcherViewViewModel(ISampleAppData sampleAppData)
		{
			this.appData = sampleAppData;

			this.ClipBoardDatas = this.appData.Stocks
				.ToReadOnlyReactiveCollection(d => new WatchedClipBoardDataViewModel(d))
				.AddTo(this.disposables);
		}

		#endregion

		#region デストラクタ

		public void Destroy()
		{
			this.disposables.Dispose();
		}

		#endregion
	}
}
