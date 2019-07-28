using WpfPrism72.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace WpfPrism72
{
	public class MessageBoxLibModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
 
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterDialog<NotificationMessageBox, ViewModels.NotificationMessageBoxViewModel>();
		}
	}
}