using Prism.Ioc;
using Prism.Modularity;
using WpfTestApp.Views;

namespace WpfTestApp
{
	public class EditorViewsModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
 
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<PersonalEditor>();
			containerRegistry.RegisterForNavigation<PhysicalEditor>();
			containerRegistry.RegisterForNavigation<TestPointEditor>();
			containerRegistry.RegisterForNavigation<CategoryPanel>();
		}
	}
}