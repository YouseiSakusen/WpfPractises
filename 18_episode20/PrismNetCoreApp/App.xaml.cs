using System;
using System.Reflection;
using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using PrismNetCoreApp.PersonalManagements;

namespace PrismNetCoreApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		#region オーバーライド

		private string dataFilePath = string.Empty;

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			if (e.Args.Length == 1)
				this.dataFilePath = e.Args[0];
		}

		/// <summary>ViewとViewModelの名前付け規則を設定します。</summary>
		protected override void ConfigureViewModelLocator()
		{
			base.ConfigureViewModelLocator();

			ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(vt =>
			{
				var viewName = vt.FullName;
				var asmName = vt.GetTypeInfo().Assembly.FullName;
				var vmName = $"{viewName}ViewModel, {asmName}";

				return Type.GetType(vmName);
			});
		}

		protected override Window CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}

		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			moduleCatalog.AddModule<NavigationPanelModule>();
			moduleCatalog.AddModule<PersonSelectDialogModule>();
			moduleCatalog.AddModule<EditorPanelsModule>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterInstance<IPrismNetCoreData>(new PrismNetCoreAgent().LoadData(this.dataFilePath));
			containerRegistry.RegisterDialogWindow<PrismNetCoreAppWindow>();
		}

		#endregion
	}
}
