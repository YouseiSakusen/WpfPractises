using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace WpfTestApp.ViewModels
{
	public class TreeViewItemViewModel : BindableBase, IDisposable
	{
		#region "プロパティ"

		/// <summary>TreeViewItemのテキストを取得します。</summary>
		public ReadOnlyReactivePropertySlim<string> ItemText { get; }

		/// <summary>TreeViewItem のImageを取得します</summary>
		public ReactiveProperty<System.Windows.Media.ImageSource> ItemImage { get; }

		/// <summary>子ノードを取得します。</summary>
		public ReactiveCollection<TreeViewItemViewModel> Children { get; }

		/// <summary>TreeViewItem の元データを取得します。</summary>
		public object SourceData { get; } = null;

		/// <summary>TreeViewItemが展開されているかを取得・設定します。</summary>
		public ReactivePropertySlim<bool> IsExpanded { get; set; }

		/// <summary>TreeViewItemが選択されているかを取得・設定します。</summary>
		public ReactivePropertySlim<bool> IsSelected { get; set; }

		#endregion

		/// <summary>Childrenプロパティに新規Itemを追加します。</summary>
		private void addNewItem()
		{

		}

		#region "コンストラクタ"

		/// <summary>カテゴリノードかどうかを取得・設定します。</summary>
		private ReactivePropertySlim<bool> IsCategory { get; set; }

		/// <summary>新規データ追加コマンド</summary>
		public ReactiveCommand AddNewDataCommand { get; }

		/// <summary>ReactivePropertyのDispose用リスト</summary>
		private System.Reactive.Disposables.CompositeDisposable disposables
			= new System.Reactive.Disposables.CompositeDisposable();

		/// <summary>親のViewModel。</summary>
		private NavigationTreeViewModel parent = null;

		/// <summary>ツリーノードのカテゴリ。</summary>
		private TreeNodeCategoryType nodeCategory = TreeNodeCategoryType.NoCategory;

		/// <summary>コンストラクタ</summary>
		/// <param name="treeItem">TreeViewItem の元データを表すobject。</param>
		/// <param name="parentViewModel">このViewModelの親を表すNavigationTreeViewModel。</param>
		public TreeViewItemViewModel(object treeItem, NavigationTreeViewModel parentViewModel)
		{
			this.parent = parentViewModel;
			this.Children = new ReactiveCollection<TreeViewItemViewModel>()
				.AddTo(this.disposables);

			this.SourceData = treeItem;
			var imageFileName = string.Empty;

			switch (this.SourceData)
			{
				case PersonalInformation p:
					this.ItemText = p.ObserveProperty(x => x.Name)
						.ToReadOnlyReactivePropertySlim()
						.AddTo(this.disposables);

					imageFileName = "user.png";
					break;
				case PhysicalInformation ph:
					this.ItemText = ph.ObserveProperty(x => x.MeasurementDate)
						.Select(d => d.HasValue ? d.Value.ToString("yyy年MM月dd日") : "新しい測定")
						.ToReadOnlyReactivePropertySlim()
						.AddTo(this.disposables);

					imageFileName = "heart.png";
					break;
				case TestPointInformation t:
					this.ItemText = t.ObserveProperty(x => x.TestDate)
						.ToReadOnlyReactivePropertySlim()
						.AddTo(this.disposables);

					imageFileName = "test.png";
					break;
				case string s:
					this.ItemText = this.ObserveProperty(x => x.SourceData)
						.Select(v => v as string)
						.ToReadOnlyReactivePropertySlim()
						.AddTo(this.disposables);

					if (s == "身体測定") { imageFileName = "physical_folder.png"; }
					else if (s == "試験結果") { imageFileName = "test_folder.png"; }
					break;
			}

			var img = new System.Windows.Media.Imaging.BitmapImage(
				new Uri("pack://application:,,,/NavigationTree;component/Resources/" + imageFileName,
						UriKind.Absolute));
			this.ItemImage = new ReactiveProperty<System.Windows.Media.ImageSource>(img)
				.AddTo(this.disposables);

			this.IsExpanded = new ReactivePropertySlim<bool>(true)
				.AddTo(this.disposables);
			this.IsSelected = new ReactivePropertySlim<bool>(false)
				.AddTo(this.disposables);
			this.IsCategory = new ReactivePropertySlim<bool>(this.SourceData != null && this.SourceData is string)
				.AddTo(this.disposables);

			this.AddNewDataCommand = new List<IObservable<bool>>()
				{
					this.IsCategory,
					this.IsSelected
				}
				.CombineLatestValuesAreAllTrue()
				.ToReactiveCommand()
				.AddTo(this.disposables);
			this.AddNewDataCommand.Subscribe(() => this.addNewItem());
		}

		/// <summary>コンストラクタ。</summary>
		/// <summary>コンストラクタ</summary>
		/// <param name="treeItem">TreeViewItem の元データを表すobject。</param>
		/// <param name="parentViewModel">このViewModelの親を表すNavigationTreeViewModel。</param>
		/// <param name="categoryType">カテゴリの種類を表す列挙型の内の1つ。。</param>
		public TreeViewItemViewModel(string treeItem, 
									 NavigationTreeViewModel parentViewModel,
									 TreeNodeCategoryType categoryType)
			: this(treeItem, parentViewModel)
		{
			this.nodeCategory = categoryType;
		}

		#endregion

		/// <summary>オブジェクトを破棄します。</summary>
		void IDisposable.Dispose() { this.disposables.Dispose(); }
	}
}
