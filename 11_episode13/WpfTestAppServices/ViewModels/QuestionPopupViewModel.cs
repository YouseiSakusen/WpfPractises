using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using Prism.Mvvm;
using Prism.Interactivity.InteractionRequest;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace WpfTestApp.ViewModels
{
	public class QuestionPopupViewModel : BindableBase, IInteractionRequestAware
	{
		public ReactiveProperty<string> Title { get; private set; }
		public ReactiveProperty<string> Content { get; private set; }

		//public INotification Notification { get; set; }

		private IConfirmation notify;
		/// <summary>測定日を取得・設定します。</summary>
		public INotification Notification
		{
			get { return notify; }
			set
			{
				SetProperty(ref notify, (IConfirmation)value);

				this.Title = new ReactiveProperty<string>(this.Notification.Title)
					.AddTo(this.disposables);
				this.Content = new ReactiveProperty<string>(this.Notification.Content.ToString())
					.AddTo(this.disposables);
				this.RaisePropertyChanged(null);
			}
		}

		public Action FinishInteraction { get; set; }

		public ReactiveCommand CancelCommand { get; }
		public ReactiveCommand YesCommand { get; }

		private void CancelButtonClick()
		{
			this.notify.Confirmed = false;
			this.FinishInteraction?.Invoke();
		}

		private void YesButtonClick()
		{
			this.notify.Confirmed = true;
			this.FinishInteraction?.Invoke();
		}

		private CompositeDisposable disposables = new CompositeDisposable();

		public QuestionPopupViewModel()
		{
			this.CancelCommand = new ReactiveCommand()
				.AddTo(this.disposables);
			this.CancelCommand.Subscribe(() => this.CancelButtonClick());

			this.YesCommand = new ReactiveCommand()
				.AddTo(this.disposables);
			this.YesCommand.Subscribe(() => this.YesButtonClick());
		}
	}
}
