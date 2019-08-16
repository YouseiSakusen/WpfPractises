using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace WpfPrism72.CommonDialog
{
	public class CommonDialogLibModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
 
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			//containerRegistry.RegisterInstance<IOpenFileDialogService>(new OpenFileDialogService());
		}
	}
}