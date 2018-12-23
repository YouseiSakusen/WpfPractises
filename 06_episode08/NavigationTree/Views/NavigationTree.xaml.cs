using System.Windows.Controls;
using System.Windows.Input;

namespace WpfTestApp.Views
{
	/// <summary>Interaction logic for NavigationTree</summary>
	public partial class NavigationTree : UserControl
	{
		public NavigationTree()
		{
			InitializeComponent();
		}

		/// <summary>TreeViewItemのPreviewMouseRightButtonDownイベントハンドラ。</summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているMouseButtonEventArgs。</param>
		private void TreeViewItem_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			var item = sender as TreeViewItem;
			if (item == null)
				return;

			item.IsSelected = true;
		}
	}
}
