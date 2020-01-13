using Prism.Interactivity.InteractionRequest;

namespace WpfTestApp.Notifications
{
	interface ISearchDialogNotification : IConfirmation
	{
		Character SelectedCharacter { get; set; }
	}
}
