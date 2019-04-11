using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Interactivity.InteractionRequest;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace WpfTestApp.ViewModels
{
	public class SearchDialogViewModel : BindableBase, IInteractionRequestAware
	{
		public ReadOnlyReactiveCollection<SearchItemViewModel> Characters { get; }

		public ReactiveProperty<SearchItemViewModel> SelectedItem { get; set; }

		private Notifications.ISearchDialogNotification notification;
		public INotification Notification
		{
			get { return notification; }
			set { this.SetProperty(ref notification, (Notifications.ISearchDialogNotification)value); }
		}

		public Action FinishInteraction { get; set; }

		public ReactiveCommand OkCommand { get; }

		public ReactiveCommand ListBoxDoubleClick { get; }

		private void listBox_DoubleClick()
		{
			if (this.SelectedItem.Value == null)
				return;

			this.okButton_Click();
		}

		private void okButton_Click()
		{
			this.notification.Confirmed = true;
			this.notification.SelectedCharacter = this.SelectedItem.Value.TargetCharacter;
			this.FinishInteraction.Invoke();
		}

		private ObservableCollection<Character> bleachCharacters { get; set; }

		private CompositeDisposable disposables = new CompositeDisposable();

		public SearchDialogViewModel()
		{
			var agent = new BleachAgent();
			this.bleachCharacters = new ObservableCollection<Character>();
			this.bleachCharacters.AddRange(agent.GetAllCharacters());

			this.Characters = this.bleachCharacters
				.ToReadOnlyReactiveCollection(c => new SearchItemViewModel(c))
				.AddTo(this.disposables);

			this.SelectedItem = new ReactiveProperty<SearchItemViewModel>()
				.AddTo(this.disposables);

			this.OkCommand = new ReactiveCommand()
				.AddTo(this.disposables);
			this.OkCommand.Subscribe(() => this.okButton_Click());

			this.ListBoxDoubleClick = new ReactiveCommand()
				.AddTo(this.disposables);
			this.ListBoxDoubleClick.Subscribe(() => this.listBox_DoubleClick());
		}
	}
}
