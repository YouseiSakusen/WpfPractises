using Prism.Ioc;
using Prism.Modularity;

namespace WpfPrism72
{
	public class WpfPrism72DialogModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
 
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterDialog<Views.BleachDialog, ViewModels.BleachDialogViewModel>();
		}
	}
}