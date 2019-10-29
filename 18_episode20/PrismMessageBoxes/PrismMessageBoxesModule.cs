using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismNetCoreApp.MessageBoxes;

namespace PrismNetCoreApp
{
	public class PrismMessageBoxesModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{

		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterDialog<ConfirmMessageBox, ConfirmMessageBoxViewModel>();
		}
	}
}