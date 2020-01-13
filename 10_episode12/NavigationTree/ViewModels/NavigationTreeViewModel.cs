using System;
using System.Windows;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace WpfTestApp.ViewModels
{
	/// <summary>ツリーのカテゴリタイプを表す列挙型。</summary>
	public enum TreeNodeCategoryType
	{
		/// <summary>カテゴリなし</summary>
		NoCategory,
		/// <summary>身体測定を表します。</summary>
		Physical,
		/// <summary>試験結果を表します。</summary>
		TestPoint
	}

	/// <summary>NavigationTreeのViewModelを表します。</summary>
	public class NavigationTreeViewModel : BindableBase, IDisposable
	{
		#region "プロパティ"

		/// <summary>TreeViewItem を取得します。</summary>
		public ReadOnlyReactiveCollection<TreeViewItemViewModel> TreeNodes { get; }

		/// <summary>SelectedItemChangedイベントハンドラ。</summary>
		public ReactiveCommand<RoutedPropertyChangedEventArgs<object>> SelectedItemChanged { get; }

		/// <summary>UserControlのLoadedイベントハンドラ。</summary>
		public ReactiveCommand Loaded { get; }

		#endregion

		/// <summary>パラメータで指定したカテゴリ配下のアイテムを新規作成します。</summary>
		/// <param name="categoryType">新規作成するカテゴリを表すTreeNodeCategoryType列挙型の内の1つ。</param>
		/// <returns>新規作成したアイテムをセットしたTreeViewItemViewModel。</returns>
		internal TreeViewItemViewModel createNewChild(TreeNodeCategoryType categoryType)
		{
			object newItem = null;
			switch (categoryType)
			{
				case TreeNodeCategoryType.Physical:
					newItem = this.appData.CreateNewData<PhysicalInformation>();
					appData.Physicals.Add(newItem as PhysicalInformation);
					break;
				case TreeNodeCategoryType.TestPoint:
					newItem = this.appData.CreateNewData<TestPointInformation>();
					appData.TestPoints.Add(newItem as TestPointInformation);
					break;
			}

			return new TreeViewItemViewModel(newItem, this);
		}

		
		private bool skipNodeChange = false;

		/// <summary>SelectedItemChangedイベントハンドラ。</summary>
		/// <param name="e">イベントデータを格納しているRoutedPropertyChangedEventArgs<object>。</param>
		private void nodeChanged(RoutedPropertyChangedEventArgs<object> e)
		{
			if (this.skipNodeChange)
			{
				this.skipNodeChange = false;
				return;
			}

			var viewName = string.Empty;
			var current = e.NewValue as TreeViewItemViewModel;

			switch (current.SourceData)
			{
				case PersonalInformation p:
					viewName = "PersonalEditor";
					break;
				case PhysicalInformation p:
					viewName = "PhysicalEditor";
					break;
				case TestPointInformation t:
					viewName = "TestPointEditor";
					break;
				case string s:
					viewName = "CategoryPanel";
					break;
			}

			var param = new Prism.Regions.NavigationParameters();
			param.Add("TargetData", current.SourceData);

			this.regionManager.RequestNavigate("EditorArea", viewName, r =>
			{
				if ((r.Result.HasValue) && (!r.Result.Value))
				{
					var oldNode = e.OldValue as TreeViewItemViewModel;
					this.skipNodeChange = true;
					oldNode.IsSelected.Value = true;
				}
			}, param);
		}

		private WpfTestAppData appData = null;
		private TreeViewItemViewModel rootNode = null;
		private Prism.Regions.IRegionManager regionManager = null;
		/// <summary>ReactivePropertyのDispose用リスト</summary>
		private System.Reactive.Disposables.CompositeDisposable disposables
			= new System.Reactive.Disposables.CompositeDisposable();

		/// <summary>コンストラクタ。</summary>
		/// <param name="data">アプリのデータオブジェクト（Unity からインジェクション）</param>
		/// <param name="rm">IRegionManager（Unity からインジェクション）</param>
		public NavigationTreeViewModel(WpfTestAppData data, Prism.Regions.IRegionManager rm)
		{
			this.appData = data;
			this.regionManager = rm;

			this.rootNode = TreeViewItemCreator.Create(this.appData, this);
			var col = new System.Collections.ObjectModel.ObservableCollection<TreeViewItemViewModel>();

			col.Add(this.rootNode);
			this.TreeNodes = col.ToReadOnlyReactiveCollection()
				.AddTo(this.disposables);

			this.SelectedItemChanged = new ReactiveCommand<System.Windows.RoutedPropertyChangedEventArgs<object>>()
				.AddTo(this.disposables);
			this.SelectedItemChanged.Subscribe(e => this.nodeChanged(e));

			this.Loaded = new ReactiveCommand()
				.AddTo(this.disposables);
			this.Loaded.Subscribe(() => this.rootNode.IsSelected.Value = true);
		}

		void IDisposable.Dispose() { this.disposables.Dispose(); }
	}
}
