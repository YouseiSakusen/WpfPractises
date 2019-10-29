using System;
using System.Linq;
using System.Reactive.Disposables;
using System.Windows;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Regions;
using PrismNetCoreApp.Helpers;
using PrismNetCoreApp.NavigationItems;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace PrismNetCoreApp
{
	/// <summary>画面切り替え用のTreeViewパネルを表します。</summary>
	public class NavigationTreeViewModel : BindableBase, IDisposable, IDestructible
	{
		#region プロパティ

		/// <summary>TreeViewに表示するTreeItemを取得します。</summary>
		public ReactiveCollection<NavigationItemViewModel> TreeItems { get; }

		#endregion

		#region コマンド

		/// <summary>
		/// Loadedコマンドを取得します。
		/// </summary>
		public ReactiveCommand Loaded { get; }

		#region SelectedItemChangedコマンド

		/// <summary>
		/// SelectedItemChangedコマンドを取得します。
		/// </summary>
		public ReactiveCommand<RoutedPropertyChangedEventArgs<object>> SelectedItemChanged { get; }

		/// <summary>
		/// SelectedItemChangedコマンドハンドラ。
		/// </summary>
		/// <param name="e">イベントデータを格納しているRoutedPropertyChangedEventArgs<object>。</param>
		private void onSelectedItemChanged(RoutedPropertyChangedEventArgs<object> e)
		{
			var viewName = this.getViewName(e.NewValue as NavigationItemViewModel);
			if (string.IsNullOrEmpty(viewName))
				return;

			this.regionManager.RequestNavigate("EditorArea", viewName);
		}

		/// <summary>
		/// View名を取得します。
		/// </summary>
		/// <param name="vm">TreeViewItemのVMを表すNavigationItemViewModel。</param>
		/// <returns>View銘を表す文字列。</returns>
		private string getViewName(NavigationItemViewModel vm)
		{
			if (vm == null)
				return string.Empty;

			switch (vm.ItemCategory.Value)
			{
				case NavigationCategory.PersonalInformation:
					return "PersonalPanel";
				case NavigationCategory.PhysicalInformation:
					return "PhysicalPanel";
				case NavigationCategory.ExamInformation:
					return "ExamPanel";
				case NavigationCategory.CategoryRoot:
					return "CategoryPanel";
			}

			return string.Empty;
		}

		#endregion

		#endregion

		#region IDisposable Support

		private bool disposedValue = false; // 重複する呼び出しを検出するには

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					this.disposables.Dispose();
				}

				// TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
				// TODO: 大きなフィールドを null に設定します。

				disposedValue = true;
			}
		}

		// TODO: 上の Dispose(bool disposing) にアンマネージ リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
		// ~NavigationTreeViewModel()
		// {
		//   // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
		//   Dispose(false);
		// }

		// このコードは、破棄可能なパターンを正しく実装できるように追加されました。
		public void Dispose()
		{
			// このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
			Dispose(true);
			// TODO: 上のファイナライザーがオーバーライドされる場合は、次の行のコメントを解除してください。
			// GC.SuppressFinalize(this);
		}

		/// <summary>ViewModelを破棄します。</summary>
		public void Destroy()
			=> this.Dispose();

		#endregion

		#region コンストラクタ

		/// <summary>Prism Navigation用のIRegionManagerを表します。</summary>
		private IRegionManager regionManager = null;

		/// <summary>IDisposableなオブジェクトを一括でDisposeします。</summary>
		private CompositeDisposable disposables = new CompositeDisposable();

		/// <summary>デフォルトコンストラクタ。</summary>
		/// <param name="regionMan">Navigation実行用のIRegionManager。</param>
		/// <param name="appData">アプリケーションデータを表すIPrismNetCoreData。</param>
		public NavigationTreeViewModel(IRegionManager regionMan, IPrismNetCoreData appData)
		{
			this.regionManager = regionMan;

			this.TreeItems = new ReactiveCollection<NavigationItemViewModel>()
				.AddTo(this.disposables);
			this.TreeItems.Add(TreeViewItemHelper.CreateTreeItem(appData.TargetPerson));

			this.SelectedItemChanged = new ReactiveCommand<RoutedPropertyChangedEventArgs<object>>()
				.WithSubscribe(e => this.onSelectedItemChanged(e))
				.AddTo(this.disposables);

			this.Loaded = new ReactiveCommand()
				.WithSubscribe(() => this.TreeItems.First().IsSelected.Value = true)
				.AddTo(this.disposables);
		}

		#endregion
	}
}
