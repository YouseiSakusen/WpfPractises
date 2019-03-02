using System.ComponentModel;
using Prism.Mvvm;
using Prism.Interactivity.InteractionRequest;
using Reactive.Bindings;

namespace WpfTestApp.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		private string _title = "Prism Application";
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		public ReactiveCommand<CancelEventArgs> ClosingCommand { get; set; }

		public InteractionRequest<INotification> NotificationMessage { get; set; }

		private CancelEventArgs windowClosing(CancelEventArgs e)
		{
			e.Cancel = true;

			return e;
		}

		private IMessageBoxService messageBoxService = null;

		public MainWindowViewModel(IMessageBoxService messageService)
		{
			this.messageBoxService = messageService;
			this.NotificationMessage = this.messageBoxService.NotificationRequest;

			this.ClosingCommand = new ReactiveCommand<CancelEventArgs>()
				.WithSubscribe(e => { this.windowClosing(e); });
		}
	}
}
