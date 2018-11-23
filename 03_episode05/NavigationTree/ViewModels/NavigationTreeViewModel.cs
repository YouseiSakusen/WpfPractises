using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace WpfTestApp.ViewModels
{
	public class NavigationTreeViewModel : BindableBase, System.IDisposable
	{
		/// <summary>TreeViewItem を取得します。</summary>
		public ReadOnlyReactiveCollection<TreeViewItemViewModel> TreeNodes { get; }

		private WpfTestAppData appData = null;
		private TreeViewItemViewModel rootNode = null;
		/// <summary>ReactivePropertyのDispose用リスト</summary>
		private System.Reactive.Disposables.CompositeDisposable disposables
			= new System.Reactive.Disposables.CompositeDisposable();

		/// <summary>コンストラクタ。</summary>
		/// <param name="data">アプリのデータオブジェクト（Unity からインジェクション）</param>
		public NavigationTreeViewModel(WpfTestAppData data)
		{
			this.appData = data;

			this.rootNode = TreeViewItemCreator.Create(this.appData);
			var col = new System.Collections.ObjectModel.ObservableCollection<TreeViewItemViewModel>();

			col.Add(this.rootNode);
			this.TreeNodes = col.ToReadOnlyReactiveCollection()
				.AddTo(this.disposables);
		}

		void System.IDisposable.Dispose() { this.disposables.Dispose(); }
	}
}
