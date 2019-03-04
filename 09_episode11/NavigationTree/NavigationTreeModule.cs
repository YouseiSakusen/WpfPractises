using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace WpfTestApp
{
	public class NavigationTreeModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var regionMan = containerProvider.Resolve<IRegionManager>();
			regionMan.RegisterViewWithRegion("NaviTree", typeof(Views.NavigationTree));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			
		}
	}
}