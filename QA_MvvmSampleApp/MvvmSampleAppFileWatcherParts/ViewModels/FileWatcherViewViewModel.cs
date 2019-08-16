using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MvvmSampleApp.FileWatchers.ViewModels
{
	public class FileWatcherViewViewModel : BindableBase, IDestructible
	{
		#region プロパティ

		public ReadOnlyReactiveCollection<WatchedFileViewModel> WatchedFiles { get; }

		#endregion

		#region コンストラクタ

		private ISampleAppData appData = null;
		private IRegionManager regionManager = null;
		private CompositeDisposable disposables = new CompositeDisposable();

		public FileWatcherViewViewModel(ISampleAppData sampleAppData, IRegionManager regionMan)
		{
			this.appData = sampleAppData;
			this.regionManager = regionMan;

			this.WatchedFiles = this.appData.WatchedFiles
				.ToReadOnlyReactiveCollection(f => new WatchedFileViewModel(f))
				.AddTo(this.disposables);

			this.WatchedFiles.ObserveAddChanged()
				.Subscribe(_ => this.regionManager.RequestNavigate("ContentRegion", "FileWatcherView"));
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
