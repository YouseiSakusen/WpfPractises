using VmLoadTest.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace VmLoadTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
			containerRegistry.RegisterForNavigation<ViewA>();
			containerRegistry.RegisterForNavigation<ViewB>();
        }
    }
}
