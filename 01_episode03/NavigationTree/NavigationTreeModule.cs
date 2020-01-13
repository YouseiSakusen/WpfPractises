using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace WpfTestApp
{
    public class NavigationTreeModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public NavigationTreeModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            this._regionManager.RegisterViewWithRegion("NaviTree", typeof(WpfTestApp.Views.NavigationTree));
        }
    }
}
