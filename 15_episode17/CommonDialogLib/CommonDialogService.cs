using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPrism72.CommonDialogs.InnerServices;

namespace WpfPrism72.CommonDialogs
{
	public class CommonDialogService : ICommonDialogService
	{
		public bool ShowDialog(IDialogSettings settings)
		{
			var service = this.createInnerService(settings);
			if (service == null)
				return false;

			return service.ShowDialog(settings);
		}

		private ICommonDialogService createInnerService(IDialogSettings settings)
		{
			if (settings == null)
				return null;

			if ((settings is ApiPackFolderBrowsDialogSettings) || (settings is ApiPackSaveFileDialogSettings))
				return new CommonFileDialogService();
			else if (settings is SaveFileDialogSettings)
				return new FileDialogService();
			else
				return null;
		}
	}
}
