using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using PrismCommonDialog;
using PrismCommonDialog.Confirmations;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Input;

namespace WpfTestApp.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		/// <summary>選択したフォルダのパスを取得します。</summary>
		public ReactivePropertySlim<string> SelectedFolderPath { get; }

		/// <summary>選択したファイルのパスを取得します。</summary>
		public ReactivePropertySlim<string> SelectedFilePath { get; }

		public ReadOnlyReactivePropertySlim<string> CharacterName { get; }

		public ReactiveProperty<string> ItemCode { get; set; }

		private string _title = "Prism Application";
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		public IInteractionRequest DialogRequest { get; }

		/// <summary>ファイルを開くダイアログの表示を要求するためのIInteractionRequestを取得します。</summary>
		public IInteractionRequest OpenFileDialogRequest { get; }

		public ReadOnlyReactivePropertySlim<Type> DialogContents { get; }

		public ReactiveCommand OokiiDialogCommand { get; }

		/// <summary>MVVMパターンでShowDialogボタンのClickコマンドを取得します。</summary>
		public ReactiveCommand OpenFileDialogCommand { get; }

		public ReactiveCommand ShowDialogCommand { get; }

		public ReactiveCommand<KeyEventArgs> ItemCodeKeyDown { get; }

		public ReactiveCommand SearchCommand { get; }

		/// <summary>MVVMパターンでフォルダ選択ダイアログを表示します。</summary>
		private void ShowOokiiDialog_Click()
		{
			var dlgConfirm = new FolderSelectDialogConfirmation()
			{
				Title = "大きいDialog"
			};

			if (this.commonDialogService.ShowDialog(dlgConfirm) == System.Windows.MessageBoxResult.OK)
			{
				this.SelectedFolderPath.Value = dlgConfirm.SelectedPath;
			}
		}

		/// <summary>MVVMパターンでShowDialogボタンのClickコマンドを処理します。</summary>
		private void showOpenFileDialog()
		{
			var openFileComfirm = new OpenFileDialogConfirmation()
			{
				Title = "ファイルを開く"
			};

			if (this.commonDialogService.ShowDialog(openFileComfirm) == System.Windows.MessageBoxResult.OK)
			{
				this.SelectedFolderPath.Value = openFileComfirm.FileName;
			}
		}

		private void showDialogButton_Click()
		{
			var dlg = new Microsoft.Win32.OpenFileDialog();
			dlg.ShowDialog();
		}

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
		private ICommonDialogService commonDialogService = null;
		private Character chara { get; set; } = new Character();

		public MainWindowViewModel(IDialogService dialogSrv, ICommonDialogService comDlgService)
		{
			this.dialogService = dialogSrv;
			this.DialogRequest = this.dialogService.DialogRequest;

			this.commonDialogService = comDlgService;
			this.OpenFileDialogRequest = this.commonDialogService.CommonDialogRequest;

			this.ItemCode = this.chara.Code
				.ToReactiveProperty()
				.AddTo(this.disposables);

			this.CharacterName = this.chara.Name
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			this.SelectedFilePath = new ReactivePropertySlim<string>(string.Empty)
				.AddTo(this.disposables);

			this.SelectedFolderPath = new ReactivePropertySlim<string>(string.Empty)
				.AddTo(this.disposables);

			this.ItemCodeKeyDown = new ReactiveCommand<KeyEventArgs>()
				.AddTo(this.disposables);
			this.ItemCodeKeyDown.Subscribe(e => this.itemCode_keyDown(e));

			this.SearchCommand = new ReactiveCommand()
				.AddTo(this.disposables);
			this.SearchCommand.Subscribe(() => this.searchRefButton_Click());

			this.ShowDialogCommand = new ReactiveCommand()
				.AddTo(this.disposables);
			this.ShowDialogCommand.Subscribe(() => this.showDialogButton_Click());

			this.OpenFileDialogCommand = new ReactiveCommand()
				.AddTo(this.disposables);
			this.OpenFileDialogCommand.Subscribe(() => this.showOpenFileDialog());

			this.OokiiDialogCommand = new ReactiveCommand()
				.AddTo(this.disposables);

		}
	}
}
