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
		private string dataFilePath = string.Empty;

		protected override void OnStartup(StartupEventArgs e)
		{
			if (e.Args.Length == 1) { this.dataFilePath = e.Args[0]; }

			base.OnStartup(e);
		}

		protected override Window CreateShell()
		{
			//if (this.dataFilePath == string.Empty) { this.Shutdown(); }
			return Container.Resolve<MainWindow>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterInstance<WpfTestAppData>(DataLoader.Load(this.dataFilePath));
		}

		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			moduleCatalog.AddModule<NavigationTreeModule>(InitializationMode.WhenAvailable);
		}
	}
}
