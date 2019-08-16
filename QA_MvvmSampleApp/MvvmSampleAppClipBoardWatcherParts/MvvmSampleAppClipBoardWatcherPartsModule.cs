using MvvmSampleApp.ClipBoardWatchers.ViewModels;
using MvvmSampleApp.ClipBoardWatchers.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace MvvmSampleApp.ClipBoardWatchers
{
	public class MvvmSampleAppClipBoardWatcherPartsModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
 
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<ClipBoardWatcherView, ClipBoardWatcherViewViewModel>();
		}
	}
}