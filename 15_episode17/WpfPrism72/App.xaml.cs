using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using WpfPrism72.CommonDialogs;
using WpfPrism72.Views;

namespace WpfPrism72
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		/// <summary>DIコンテナへ型を登録します。</summary>
		/// <param name="containerRegistry">DIコンテナへの型を登録するIContainerRegistry</param>
		protected override void RegisterTypes(IContainerRegistry containerRegistry)
			=> containerRegistry.RegisterSingleton<ICommonDialogService, CommonDialogService>();

		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			moduleCatalog.AddModule<MessageBoxLibModule>();
			moduleCatalog.AddModule<WpfPrism72DialogModule>();
		}

		protected override Window CreateShell()
			=> Container.Resolve<MainWindow>();
	}
}
