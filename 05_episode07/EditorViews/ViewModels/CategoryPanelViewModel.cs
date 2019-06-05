using Prism.Mvvm;
using Prism.Regions;

namespace WpfTestApp.ViewModels
{
	/// <summary>カテゴリパネルのViewModel</summary>
	public class CategoryPanelViewModel : BindableBase, IRegionMemberLifetime
	{
		/// <summary>非Active時にインスタンスを保持するかを取得します。</summary>
		public bool KeepAlive => false;

		/// <summary>コンストラクタ。</summary>
		public CategoryPanelViewModel() { }
	}
}
