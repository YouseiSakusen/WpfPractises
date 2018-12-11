using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestApp.ViewModels
{
	internal static class TreeViewItemCreator
	{
		internal static TreeViewItemViewModel Create(WpfTestAppData appData)
		{
			var rootNode = new TreeViewItemViewModel(appData.Student);
			var physicalClass = new TreeViewItemViewModel("身体測定");
			rootNode.Children.Add(physicalClass);

			foreach (var item in appData.Physicals)
			{
				var child = new TreeViewItemViewModel(item);
				physicalClass.Children.Add(child);
			}

			var testPointClass = new TreeViewItemViewModel("試験結果");
			rootNode.Children.Add(testPointClass);

			foreach (var item in appData.TestPoints)
			{
				var child = new TreeViewItemViewModel(item);
				testPointClass.Children.Add(child);
			}

			return rootNode;
		}
	}
}
