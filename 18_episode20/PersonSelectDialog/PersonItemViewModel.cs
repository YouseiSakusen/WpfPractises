using System;
using System.Reactive.Disposables;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace PrismNetCoreApp
{
	public class PersonItemViewModel : BindableBase, IDisposable
	{
		#region プロパティ

		public ReadOnlyReactivePropertySlim<string> Code { get; }

		public ReadOnlyReactivePropertySlim<string> Yomigana { get; }

		public ReadOnlyReactivePropertySlim<string> Name { get; }

		public ReadOnlyReactivePropertySlim<string> Equipment { get; }

		public ReadOnlyReactivePropertySlim<string> SpecialSkill { get; }

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
		// ~PersonItemViewModel()
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

		private PersonalInformation personInfo = null;

		private CompositeDisposable disposables = new CompositeDisposable();

		public PersonItemViewModel(PersonalInformation person)
		{
			this.personInfo = person;

			this.Code = this.personInfo.Code
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			this.Yomigana = this.personInfo.Yomigana
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			this.Name = this.personInfo.Name
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			this.Equipment = this.personInfo.Equipment
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			this.SpecialSkill = this.personInfo.SpecialSkill
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);
		}

		#endregion
	}
}
