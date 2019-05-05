using System;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Reactive.Bindings;

namespace WpfTestApp.ViewModels
{
	public class SearchDialogViewModel : BindableBase, IInteractionRequestAware
	{
		/// <summary>ListBoxのItemsSourceを取得します。</summary>
		public ReadOnlyReactiveCollection<SearchItemViewModel> Characters { get; }

		/// <summary>ListBoxの選択項目を取得・設定します。</summary>
		public ReactiveProperty<SearchItemViewModel> SelectedItem { get; set; }

		private Notifications.ISearchDialogNotification notification;
		/// <summary>INotificationを取得・設定します。</summary>
		public INotification Notification
		{
			get { return notification; }
			set { this.SetProperty(ref notification, (Notifications.ISearchDialogNotification)value); }
		}

		/// <summary>終了処理アクションを取得・設定します。</summary>
		public Action FinishInteraction { get; set; }

		/// <summary>OKボタンのコマンドを取得します。</summary>
		public ReactiveCommand OkCommand { get; }

		/// <summary>ListBoxのMouseDoubleClickコマンドを取得します。</summary>
		public ReactiveCommand ListBoxDoubleClick { get; }

		/// <summary>ListBoxのMouseDoubleClickイベントハンドラ。</summary>
		private void listBox_DoubleClick()
		{
			if (this.SelectedItem.Value == null)
				return;

			this.okButton_Click();
		}

		/// <summary>OKボタンのClickイベントハンドラ。</summary>
		private void okButton_Click()
		{
			this.notification.Confirmed = true;
			this.notification.SelectedCharacter = this.SelectedItem.Value.TargetCharacter;
			this.FinishInteraction.Invoke();
		}

		private ObservableCollection<Character> bleachCharacters { get; set; }

		/// <summary>コンストラクタ。</summary>
		public SearchDialogViewModel()
		{
			var charaList = new BleachAgent().GetAllCharacters();
			this.bleachCharacters = new ObservableCollection<Character>(charaList.OrderBy(c => c.Code.Value));

			this.Characters = this.bleachCharacters
				.ToReadOnlyReactiveCollection(c => new SearchItemViewModel(c));

			this.SelectedItem = new ReactiveProperty<SearchItemViewModel>(this.Characters.First());

			this.OkCommand = new ReactiveCommand();
			this.OkCommand.Subscribe(() => this.okButton_Click());

			this.ListBoxDoubleClick = new ReactiveCommand();
			this.ListBoxDoubleClick.Subscribe(() => this.listBox_DoubleClick());
		}
	}
}
