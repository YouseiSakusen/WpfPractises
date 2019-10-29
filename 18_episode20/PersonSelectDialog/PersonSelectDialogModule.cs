using Prism.Ioc;
using Prism.Modularity;

namespace PrismNetCoreApp.PersonalManagements
{
	public class PersonSelectDialogModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{

		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterDialog<PersonSelectDialog, PersonSelectDialogViewModel>();
		}
	}
}