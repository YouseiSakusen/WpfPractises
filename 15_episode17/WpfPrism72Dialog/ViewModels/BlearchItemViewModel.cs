using Prism.Commands;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;

namespace WpfPrism72.ViewModels
{
	public class BlearchItemViewModel : BindableBase
	{
		public ReadOnlyReactivePropertySlim<string> Code { get; }

		public ReadOnlyReactivePropertySlim<string> Yomigana { get; }

		public ReadOnlyReactivePropertySlim<string> Name { get; }

		public ReadOnlyReactivePropertySlim<string> Zanpakuto { get; }

		public ReadOnlyReactivePropertySlim<string> Bankai { get; }

		public BleachCharacter TargetCharacter => this.targetCharacter;

		private BleachCharacter targetCharacter = null;
		private CompositeDisposable disposables = new CompositeDisposable();

		public BlearchItemViewModel(BleachCharacter character)
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
