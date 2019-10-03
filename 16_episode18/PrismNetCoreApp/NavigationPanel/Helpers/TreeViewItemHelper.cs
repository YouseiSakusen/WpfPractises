using PrismNetCoreApp.NavigationItems;

namespace PrismNetCoreApp.Helpers
{
	internal static class TreeViewItemHelper
	{
		#region メソッド

		internal static NavigationItemViewModel CreateTreeItem(PersonalInformation person)
		{
			var root = new NavigationItemViewModel(person, null);
			root.AddViewModel(TreeViewItemHelper.createCategory(NavigationCategory.PhysicalInformation, root, person));
			root.AddViewModel(TreeViewItemHelper.createCategory(NavigationCategory.ExamInformation, root, person));

			return root;
		}

		private static NavigationItemViewModel createCategory(NavigationCategory category,
															  NavigationItemViewModel parent,
															  PersonalInformation personData)
		{
			string text = string.Empty;

			switch (category)
			{
				case NavigationCategory.PhysicalInformation:
					text = "身体測定";
					break;
				case NavigationCategory.ExamInformation:
					text = "試験結果";
					break;
			}

			return new NavigationItemViewModel(new CategoryItem(text, category), parent, personData);
		}

		#endregion
	}
}
