using WpfPrism72.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace WpfPrism72
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{

		}

		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			moduleCatalog.AddModule<MessageBoxLibModule>();
		}

		protected override Window CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}
	}
}
