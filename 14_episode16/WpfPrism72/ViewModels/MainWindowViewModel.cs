using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using System;
using System.Reactive.Linq;

namespace WpfPrism72.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		public ReactiveCommand OkButtonCommand { get; } = new ReactiveCommand();

		private string _title = "Prism Application";
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		private void showDialogCallBack(IDialogResult result)
		{

		}

		private IDialogService dlgService = null;

		public MainWindowViewModel(IDialogService dialogService)
		{
			this.dlgService = dialogService;

			this.OkButtonCommand.Subscribe(() 
				=> this.dlgService.ShowDialog("NotificationMessageBox", null, r => this.showDialogCallBack(r)));
		}
	}
}
