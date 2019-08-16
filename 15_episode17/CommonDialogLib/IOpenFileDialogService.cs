using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Services.Dialogs;

namespace WpfPrism72.CommonDialog
{
	public interface IOpenFileDialogService
	{
		bool? ShowDialog();
	}
}
