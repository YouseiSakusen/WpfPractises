using System.Linq;
using System.Reactive.Disposables;
using System.Windows;
using Prism.Mvvm;
using Prism.Regions;
using PrismNetCoreApp.Helpers;
using PrismNetCoreApp.NavigationItems;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace PrismNetCoreApp
{
	public class NavigationTreeViewModel : BindableBase
	{
		#region プロパティ

		public ReactiveCollection<NavigationItemViewModel> TreeItems { get; }

		#endregion

		#region コンストラクタ

		private IRegionManager regionManager = null;

		private CompositeDisposable disposables = new CompositeDisposable();

		public NavigationTreeViewModel(IRegionManager regionMan, IPrismNetCoreData appData)
		{
			this.regionManager = regionMan;

			this.TreeItems = new ReactiveCollection<NavigationItemViewModel>()
				.AddTo(this.disposables);
			this.TreeItems.Add(TreeViewItemHelper.CreateTreeItem(appData.TargetPerson));
		}

		#endregion
	}
}
