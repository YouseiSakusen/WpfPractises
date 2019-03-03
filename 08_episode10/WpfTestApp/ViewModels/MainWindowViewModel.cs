using System.Reactive.Disposables;
using System.ComponentModel;
using Prism.Mvvm;
using Prism.Interactivity.InteractionRequest;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

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

		public ReactiveProperty<bool> CancelClose { get; }

		public ReactiveCommand ClosingCommand { get; }

		public InteractionRequest<INotification> NotificationMessage { get; set; }

		private void windowClosing()
		{
			this.CancelClose.Value = true;
		}

		private CompositeDisposable disposables = new CompositeDisposable();
		private IMessageBoxService messageBoxService = null;

		public MainWindowViewModel(IMessageBoxService messageService)
		{
			this.messageBoxService = messageService;
			this.NotificationMessage = this.messageBoxService.NotificationRequest;

			this.CancelClose = new ReactiveProperty<bool>(false)
				.AddTo(this.disposables);

			this.ClosingCommand = new ReactiveCommand()
				.AddTo(this.disposables);
			this.ClosingCommand.Subscribe(() => this.windowClosing());
		}
	}
}
