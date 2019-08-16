using System.Windows;
using MvvmSampleApp.ClipBoardWatchers;
using MvvmSampleApp.FileWatchers;
using MvvmSampleApp.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace MvvmSampleApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		#region オーバーライド

		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			moduleCatalog.AddModule<MvvmSampleAppFileWatcherPartsModule>();
			moduleCatalog.AddModule<MvvmSampleAppClipBoardWatcherPartsModule>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterInstance<ISampleAppData>(new SampleAppData());
		}

		protected override Window CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}

		#endregion
	}
}
