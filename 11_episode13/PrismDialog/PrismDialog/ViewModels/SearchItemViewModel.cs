using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace WpfTestApp.ViewModels
{
	public class SearchItemViewModel : BindableBase
	{
		public ReadOnlyReactivePropertySlim<string> Code { get; }

		public ReadOnlyReactivePropertySlim<string> Yomigana { get; }

		public ReadOnlyReactivePropertySlim<string> Name { get; }

		public ReadOnlyReactivePropertySlim<string> Zanpakuto { get; }

		public ReadOnlyReactivePropertySlim<string> Bankai { get; }

		public Character TargetCharacter
		{
			get { return this.targetCharacter; }
		}

		private Character targetCharacter = null;
		private CompositeDisposable disposables = new CompositeDisposable();

		public SearchItemViewModel(Character character)
		{
			this.targetCharacter = character;

			this.Code = this.targetCharacter.Code
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			this.Yomigana = this.targetCharacter.Yomigana
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			this.Name = this.targetCharacter.Name
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			this.Zanpakuto = this.targetCharacter.Zanpakuto
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			this.Bankai = this.targetCharacter.Bankai
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);
		}
	}
}
