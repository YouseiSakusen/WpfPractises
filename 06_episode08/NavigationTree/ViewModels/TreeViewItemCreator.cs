using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

	/// <summary>TreeViewItemを作成します。</summary>
	internal static class TreeViewItemCreator
	{
		/// <summary>ツリー構造を作成してルートノードを返します。</summary>
		/// <param name="appData">アプリのデータを表すWpfTestAppData。</param>
		/// <param name="parent">TreeViewItemViewModelの親を表すNavigationTreeViewModel。</param>
		/// <returns>作成したツリー構造のルートノードを表すTreeViewItemViewModel。</returns>
		internal static TreeViewItemViewModel Create(WpfTestAppData appData, NavigationTreeViewModel parent)
		{
			var rootNode = new TreeViewItemViewModel(appData.Student, parent);
			var physicalClass = new TreeViewItemViewModel("身体測定", parent, TreeNodeCategoryType.Physical);
			rootNode.Children.Add(physicalClass);

			foreach (var item in appData.Physicals)
			{
				var child = new TreeViewItemViewModel(item, parent);
				physicalClass.Children.Add(child);
			}

			var testPointClass = new TreeViewItemViewModel("試験結果", parent, TreeNodeCategoryType.TestPoint);
			rootNode.Children.Add(testPointClass);

			foreach (var item in appData.TestPoints)
			{
				var child = new TreeViewItemViewModel(item, parent);
				testPointClass.Children.Add(child);
			}

			return rootNode;
		}
	}
}
