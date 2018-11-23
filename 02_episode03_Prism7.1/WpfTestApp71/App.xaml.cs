using WpfTestApp.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace WpfTestApp
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

		}

		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			moduleCatalog.AddModule<NavigationTreeModule>(InitializationMode.WhenAvailable);
		}
	}
}
