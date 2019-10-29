using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;

namespace PrismNetCoreApp
{
	public class PersonSelectDialogViewModel : BindableBase, IDialogAware, IDisposable
	{
		#region プロパティ

		public ReadOnlyReactiveCollection<PersonItemViewModel> Persons { get; }

		#endregion

		#region コマンド

		public ReactiveCommand OkCommand { get; }

		/// <summary>OKボタンのClickイベントハンドラ。</summary>
		private void onOk()
		{
			var ret = new DialogResult(ButtonResult.OK);
			this.RequestClose?.Invoke(ret);
		}

		#endregion

		#region イベント

		public event Action<IDialogResult> RequestClose;

		#endregion

		#region メソッド

		public string Title
			=> "BLEACHキャラクターから選択";

		public bool CanCloseDialog()
			=> true;

		public void OnDialogClosed()
			=> this.Dispose();

		public void OnDialogOpened(IDialogParameters parameters) { }

		#endregion

		#region IDisposable Support

		private bool disposedValue = false; // 重複する呼び出しを検出するには

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					this.disposables.Dispose();
				}

				// TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
				// TODO: 大きなフィールドを null に設定します。

				disposedValue = true;
			}
		}

		// TODO: 上の Dispose(bool disposing) にアンマネージ リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
		// ~PersonSelectDialogViewModel()
		// {
		//   // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
		//   Dispose(false);
		// }

		// このコードは、破棄可能なパターンを正しく実装できるように追加されました。
		public void Dispose()
		{
			// このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
			Dispose(true);
			// TODO: 上のファイナライザーがオーバーライドされる場合は、次の行のコメントを解除してください。
			// GC.SuppressFinalize(this);
		}

		#endregion

		#region コンストラクタ

		private ObservableCollection<PersonalInformation> personList = null;

		private CompositeDisposable disposables = new CompositeDisposable();

		public PersonSelectDialogViewModel()
		{
			this.personList = new ObservableCollection<PersonalInformation>(PersonAgent.GetAllPersons().OrderBy(p => p.Code.Value));

			this.Persons = this.personList.ToReadOnlyReactiveCollection(p => new PersonItemViewModel(p))
				.AddTo(this.disposables);

			this.OkCommand = new ReactiveCommand()
				.WithSubscribe(() => this.onOk())
				.AddTo(this.disposables);
		}

		#endregion
	}
}
