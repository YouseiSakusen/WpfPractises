using MvvmSampleApp.FileWatchers.ViewModels;
using MvvmSampleApp.FileWatchers.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace MvvmSampleApp.FileWatchers
{
	public class MvvmSampleAppFileWatcherPartsModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var regionManager = containerProvider.Resolve<IRegionManager>();
			regionManager.RegisterViewWithRegion("ContentRegion", typeof(FileWatcherView));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<FileWatcherView, FileWatcherViewViewModel>();   
		}
	}
}