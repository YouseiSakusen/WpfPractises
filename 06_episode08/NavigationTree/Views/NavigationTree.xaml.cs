using System.Windows.Controls;

namespace WpfTestApp.Views
{
	/// <summary>
	/// Interaction logic for NavigationTree
	/// </summary>
	public partial class NavigationTree : UserControl
	{
		public NavigationTree()
		{
			InitializeComponent();
		}

		private void TreeViewItem_PreviewMouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			var item = sender as TreeViewItem;
			if (item == null)
				return;

			item.IsSelected = true;
		}
	}
}
