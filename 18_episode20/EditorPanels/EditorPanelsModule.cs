using Prism.Ioc;
using Prism.Modularity;
using PrismNetCoreApp.PersonalManagements;

namespace PrismNetCoreApp
{
	public class EditorPanelsModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{

		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<PersonalPanel, PersonalPanelViewModel>();
		}
	}
}