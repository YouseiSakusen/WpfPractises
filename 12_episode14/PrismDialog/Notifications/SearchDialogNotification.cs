using Prism.Interactivity.InteractionRequest;

namespace WpfTestApp.Notifications
{
	class SearchDialogNotification : Confirmation, ISearchDialogNotification
	{
		public Character SelectedCharacter { get; set; }
	}
}
