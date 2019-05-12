using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCommonDialog.Confirmations
{
	public class FileSelectCommonDialogConfirmationBase : Confirmation
	{
		public bool AllowPropertyEditing { get; set; } = true;

		public bool EnsureFileExists { get; set; } = true;

		public bool EnsurePathExists { get; set; } = true;

		public bool EnsureValidNames { get; set; } = true;

		public string FileName { get; set; } = string.Empty;

		public IEnumerable<string> FileNames { get; set; } = new List<string>();

		public string Filter { get; set; } = string.Empty;

		public string InitialDirectory { get; set; } = string.Empty;

		public bool RestoreDirectory { get; set; } = true;
	}
}
