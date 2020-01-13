using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Input;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace WpfTestApp.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		public ReadOnlyReactivePropertySlim<string> CharacterName { get; }

		public ReactiveProperty<string> ItemCode { get; set; }

		private string _title = "Prism Application";
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		public IInteractionRequest DialogRequest { get; }

		public ReadOnlyReactivePropertySlim<Type> DialogContents { get; }

		public ReactiveCommand<KeyEventArgs> ItemCodeKeyDown { get; }

		public ReactiveCommand SearchCommand { get; }

		private void searchRefButton_Click()
		{
			var notification = new Notifications.SearchDialogNotification()
			{
				Title = "検索"
			};

			this.dialogService.ShowDialog(notification);
		}

		private void itemCode_keyDown(KeyEventArgs e)
		{
			if (e.Key != Key.Enter)
				return;

			var target = this.agent.GetCharacter(this.ItemCode.Value);
			if (target != null)
				this.chara.Name.Value = target.Name.Value;
		}

		private CompositeDisposable disposables = new CompositeDisposable();
		private BleachAgent agent = new BleachAgent();
		private IDialogService dialogService = null;
		private Character chara { get; set; } = new Character();

		public MainWindowViewModel(IDialogService dialogSrv)
		{
			this.ItemCode = this.chara.Code
				.ToReactiveProperty()
				.AddTo(this.disposables);

			this.CharacterName = this.chara.Name
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			this.ItemCodeKeyDown = new ReactiveCommand<KeyEventArgs>()
				.AddTo(this.disposables);
			this.ItemCodeKeyDown.Subscribe(e => this.itemCode_keyDown(e));

			this.SearchCommand = new ReactiveCommand()
				.AddTo(this.disposables);
			this.SearchCommand.Subscribe(() => this.searchRefButton_Click());

			this.dialogService = dialogSrv;
			this.DialogRequest = this.dialogService.DialogRequest;
		}
	}
}
