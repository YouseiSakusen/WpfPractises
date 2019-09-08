using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace WpfPrism72.CommonDialogs
{
	internal static class ApiPackDialogFilterCreator
	{
		internal static List<CommonFileDialogFilter> Create(string filter)
		{
			var filters = filter.Split(new char[] { '|' }).ToList();
			if (filters.Count % 2 != 0)
				throw new ArgumentException("Filterの設定が間違っています。");

			var retList = new List<CommonFileDialogFilter>();

			for (int i = 0; i < filters.Count; i += 2)
			{
				retList.Add(new CommonFileDialogFilter(filters[i], filters[i + 1]));
			}

			return retList;
		}
	}
}
