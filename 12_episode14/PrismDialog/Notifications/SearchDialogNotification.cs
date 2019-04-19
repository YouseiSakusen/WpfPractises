using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Interactivity.InteractionRequest;

namespace WpfTestApp.Notifications
{
	class SearchDialogNotification : Confirmation, ISearchDialogNotification
	{
		public Character SelectedCharacter { get; set; }
	}
}
