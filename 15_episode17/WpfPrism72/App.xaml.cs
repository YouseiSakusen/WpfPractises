using WpfPrism72.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using WpfPrism72.CommonDialogs;

namespace WpfPrism72
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterSingleton<ICommonDialogService, CommonDialogService>();
		}

		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			moduleCatalog.AddModule<MessageBoxLibModule>();
			moduleCatalog.AddModule<WpfPrism72DialogModule>();
		}

		protected override Window CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}
	}
}
