using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using VmLoadTest.Views;

namespace VmLoadTest.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		private string _title = "Prism Application";
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		public ReactiveCommand LoadedCommand { get; }

		private void onLoaded()
		{
			this.regionManager.RequestNavigate("TempRegion", nameof(ViewA));
			this.regionManager.RequestNavigate("TempRegion", nameof(ViewB));
		}

		private IRegionManager regionManager = null;

		public MainWindowViewModel(IRegionManager regionMan)
		{
			this.regionManager = regionMan;

			this.LoadedCommand = new ReactiveCommand()
				.WithSubscribe(() => this.onLoaded());
		}
	}
}
