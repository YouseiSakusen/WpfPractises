using System;
using System.Reactive.Disposables;
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
			=> this.disposables.Dispose();

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
		}

		#endregion
	}
}
