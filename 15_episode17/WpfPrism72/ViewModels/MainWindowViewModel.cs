using System;
using System.Reactive.Linq;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Prism.Services.Dialogs.Extensions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using WpfPrism72.CommonDialogs;
using WpfPrism72.Extensions;

namespace WpfPrism72.ViewModels
{
	/// <summary>ShellのViewModelを表します。</summary>
	public class MainWindowViewModel : BindableBase
	{
		#region プロパティ

		/// <summary>キャラクターコードを取得・設定します。</summary>
		public ReactiveProperty<string> BlearchCharacterCode { get; set; }

		/// <summary>キャラクター名を取得します。</summary>
		public ReadOnlyReactiveProperty<string> BleachCharacterName { get; }

		/// <summary>ダイアログの表示結果を取得します。</summary>
		public ReactivePropertySlim<string> DialogMessage { get; }

		/// <summary>画面のタイトルを取得・設定します。</summary>
		private string _title = "Prism Application";
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		#endregion

		#region コマンド

		/// <summary>BLEACHの登場人物選択ダイアログを表示します。</summary>
		public ReactiveCommand ShowBleachDialogCommand { get; }

		/// <summary>メッセージボックス表示ボタンのCommandを取得します。</summary>
		public ReactiveCommand ShowMessageButtonCommand { get; }

		public ReactiveCommand ShowOpenFileDialogCommand { get; }

		public ReactiveCommand ShowFolderBrowsDialogCommand { get; }

		#endregion

		#region コマンドハンドラ

		private void onShowFolderBrowsDialog()
		{
			var settings = new ApiPackFolderBrowsDialogSettings();

			if (this.commonDialogService.ShowDialog(settings))
			{

			}
		}

		private void onShowOpenFileDialog()
		{
			var settings = new OpenFileDialogSettings();

			if (this.commonDialogService.ShowDialog(settings))
			{

			}
		}

		/// <summary>メッセージボックス表示ボタンのClickイベントハンドラ。</summary>
		private void onShowMessageButtonCommand()
		{
			if (this.dlgService.ShowConfirmationMessage("通知メッセージを表示するよ！") == ButtonResult.Yes)
				this.DialogMessage.Value = "OKボタンが押されたよ！";
			else
				this.DialogMessage.Value = string.Empty;
		}

		/// <summary>キャラクターコードの変更イベントハンドラ。</summary>
		/// <param name="characterCode">現在入力されているキャラクターコードを表す文字列。</param>
		private void onCharacterCode(string characterCode)
		{
			var chara = new BleachAgent().GetCharacter(characterCode);
			if (chara == null)
				this.character.Code.Value = string.Empty;
			else
				this.character.Name.Value = chara.Name.Value;
		}

		/// <summary>BLEACHの登場人物選択ダイアログを表示します。</summary>
		private void showBleachDialog()
		{
			var ret = this.dlgService.ShowDialog("BleachDialog", null);
			if (ret.Result == ButtonResult.OK)
			{
				this.character.Code.Value = ret.Parameters.GetValue<BleachCharacter>("SelectedItem").Code.Value;
			}
		}

		#endregion

		#region コンストラクタ

		/// <summary>ダイアログ表示サービスを表します。</summary>
		private IDialogService dlgService = null;
		/// <summary>画面に表示しているキャラクター情報を表します。</summary>
		private BleachCharacter character { get; set; }

		private ICommonDialogService commonDialogService = null;

		/// <summary>コンストラクタ。</summary>
		/// <param name="dialogService">Prismのダイアログサービスを表すIDialogService。</param>
		public MainWindowViewModel(IDialogService dialogService, ICommonDialogService comDlgService)
		{
			this.dlgService = dialogService;
			this.commonDialogService = comDlgService;
			this.character = new BleachCharacter();

			this.ShowMessageButtonCommand = new ReactiveCommand()
				.WithSubscribe(this.onShowMessageButtonCommand);
			this.DialogMessage = new ReactivePropertySlim<string>(string.Empty);

			this.ShowBleachDialogCommand = new ReactiveCommand()
				.WithSubscribe(() => this.showBleachDialog());

			this.ShowOpenFileDialogCommand = new ReactiveCommand()
				.WithSubscribe(() => this.onShowOpenFileDialog());

			this.ShowFolderBrowsDialogCommand = new ReactiveCommand()
				.WithSubscribe(() => this.onShowFolderBrowsDialog());

			this.BlearchCharacterCode = this.character.Code;
			this.BlearchCharacterCode.Where(v => v.Length == 3)
				.Subscribe(v => this.onCharacterCode(v));

			this.BleachCharacterName = this.character.Name
				.ToReadOnlyReactiveProperty();
		}

		#endregion
	}
}