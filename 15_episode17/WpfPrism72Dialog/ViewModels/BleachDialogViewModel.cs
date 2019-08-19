using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using WpfPrism72.Extensions;

namespace WpfPrism72.ViewModels
{
	public class BleachDialogViewModel : BindableBase, IDialogAware
	{
		#region プロパティ

		/// <summary>ListBoxのItemsSourceを取得します。</summary>
		public ReadOnlyReactiveCollection<BlearchItemViewModel> Characters { get; }

		/// <summary>ListBoxの選択項目を取得・設定します。</summary>
		public ReactiveProperty<BlearchItemViewModel> SelectedItem { get; set; }

		#endregion

		#region コマンド

		/// <summary>OKボタンのコマンド。</summary>
		public ReactiveCommand OkCommand { get; }

		/// <summary>ListBoxのMouseDoubleClickコマンド。</summary>
		public ReactiveCommand ListBoxDoubleClick { get; }

		/// <summary>追加ボタンのClickコマンド。</summary>
		public ReactiveCommand AddCommand { get; }

		public event Action<IDialogResult> RequestClose;

		#endregion

		#region イベントハンドラ

		/// <summary>追加ボタンのClickイベントハンドラ。</summary>
		private void addButtonClick()
		{
			this.bleachCharacters.Add(new BleachCharacter("011", "京楽 春水", "きょうらく しゅんすい", "花天狂骨", "花天狂骨枯松心中"));
		}

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
			var param = new DialogParameters();
			param.Add("SelectedItem", this.SelectedItem.Value.TargetCharacter);

			var ret = new DialogResult(ButtonResult.OK, param);
			this.RequestClose?.Invoke(ret);
		}

		#endregion

		#region IDialogAware

		public string Title => "BLEACH登場人物";

		public bool CanCloseDialog()
		{
			return this.dialogService.ShowConfirmationMessage("画面を閉じてOK？") == ButtonResult.Yes;
		}

		public void OnDialogClosed() => this.disposables.Dispose();

		public void OnDialogOpened(IDialogParameters parameters) { }

		#endregion

		#region コンストラクタ

		private ObservableCollection<BleachCharacter> bleachCharacters { get; set; }

		private IDialogService dialogService = null;
		private CompositeDisposable disposables = new CompositeDisposable();

		/// <summary>コンストラクタ。</summary>
		public BleachDialogViewModel(IDialogService dlgService)
		{
			this.dialogService = dlgService;

			var charaList = new BleachAgent().GetAllCharacters();
			this.bleachCharacters = new ObservableCollection<BleachCharacter>(charaList.OrderBy(c => c.Code.Value));

			this.Characters = this.bleachCharacters
				.ToReadOnlyReactiveCollection(c => new BlearchItemViewModel(c))
				.AddTo(this.disposables);

			this.SelectedItem = new ReactiveProperty<BlearchItemViewModel>(this.Characters.First())
				.AddTo(this.disposables);

			this.OkCommand = new ReactiveCommand()
				.WithSubscribe(() => this.okButton_Click())
				.AddTo(this.disposables);

			this.ListBoxDoubleClick = new ReactiveCommand()
				.WithSubscribe(() => this.listBox_DoubleClick())
				.AddTo(this.disposables);

			this.AddCommand = new ReactiveCommand()
				.WithSubscribe(() => this.addButtonClick())
				.AddTo(this.disposables);
		}

		#endregion
	}
}
