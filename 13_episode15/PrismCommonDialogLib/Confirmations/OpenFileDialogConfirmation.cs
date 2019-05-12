using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCommonDialog.Confirmations
{
	public class OpenFileDialogConfirmation : FileSelectCommonDialogConfirmationBase
	{
		public bool EnsureReadOnly { get; set; } = false;

		public bool Multiselect { get; set; } = false;
	}
}
