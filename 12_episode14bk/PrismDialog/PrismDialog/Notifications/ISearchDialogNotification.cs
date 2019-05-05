using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Interactivity.InteractionRequest;

namespace WpfTestApp.Notifications
{
	interface ISearchDialogNotification : IConfirmation
	{
		Character SelectedCharacter { get; set; }
	}
}
