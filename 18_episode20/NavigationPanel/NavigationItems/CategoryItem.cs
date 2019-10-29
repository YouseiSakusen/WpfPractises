using System;
using System.Collections.Generic;
using System.Text;
using Reactive.Bindings;

namespace PrismNetCoreApp.NavigationItems
{
	public class CategoryItem : PersonalRecord
	{
		#region プロパティ

		public ReactivePropertySlim<string> ItemText { get; set; }

		public ReactivePropertySlim<NavigationCategory> Category { get; }

		#endregion

		#region コンストラクタ

		public CategoryItem(string itemText, NavigationCategory category) : base()
		{
			this.ItemText = new ReactivePropertySlim<string>(itemText);
			this.Category = new ReactivePropertySlim<NavigationCategory>(category);
		}

		#endregion
	}
}
