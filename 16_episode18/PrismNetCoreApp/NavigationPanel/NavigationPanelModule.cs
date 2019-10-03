using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace PrismNetCoreApp
{
	#region 列挙型

	/// <summary>ナビゲーションツリーのカテゴリを表す列挙型。</summary>
	public enum NavigationCategory
	{
		/// <summary>カテゴリ無しを表します。</summary>
		CategoryNone,
		/// <summary>個人情報を表します。</summary>
		PersonalInformation,
		/// <summary>身体測定情報を表します。</summary>
		PhysicalInformation,
		/// <summary>試験結果情報を表します。</summary>
		ExamInformation,
		/// <summary>カテゴリのルート要素を表します。</summary>
		CategoryRoot
	}

	#endregion

	public class NavigationPanelModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var regionManager = containerProvider.Resolve<IRegionManager>();
			regionManager.RegisterViewWithRegion("NavigationArea", typeof(NavigationTree));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{

		}
	}
}