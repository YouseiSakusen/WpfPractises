using Prism.Ioc;
using PrismCommonDialog;
using System.Windows;
using WpfTestApp.Views;

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
			// ダイアログウィンドウを表示するServiceを登録。
			containerRegistry.RegisterSingleton<IDialogService, DialogService>();
			// コモンダイアログを表示するServiceを登録。
			containerRegistry.RegisterSingleton<ICommonDialogService, CommonDialogService>();
		}
	}
}
