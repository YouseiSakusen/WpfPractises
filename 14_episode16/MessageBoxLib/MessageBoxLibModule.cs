using Prism.Ioc;
using Prism.Modularity;
using WpfPrism72.Views;

namespace WpfPrism72
{
	/// <summary>メッセーボックスモジュールを表します。</summary>
	public class MessageBoxLibModule : IModule
	{
		/// <summary>モジュールを初期化します。</summary>
		/// <param name="containerProvider"></param>
		public void OnInitialized(IContainerProvider containerProvider) { }

		/// <summary>DIコンテナへTypeを登録します。</summary>
		/// <param name="containerRegistry">登録用のDIコンテナを表すIContainerRegistry</param>
		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterDialog<NotifiedMessageBox, ViewModels.NotifiedMessageBoxViewModel>();
			containerRegistry.RegisterDialog<ConfirmedMessageBox, ViewModels.ConfirmedMessageBoxViewModel>();
		}
	}
}