using System;
using System.Reactive;
using System.Reactive.Disposables;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace WpfTestApp.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		private string _title = "Prism Application";
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		public ReactiveProperty<bool> WindowClosing { get; set; }

		private void onWindowClosing(bool value)
		{
			if (!value)
				return;

			//this.WindowClosing.Value = false;
		}

		private CompositeDisposable disposables = new CompositeDisposable();

		public MainWindowViewModel()
		{
			this.WindowClosing = new ReactiveProperty<bool>()
				.AddTo(this.disposables);
			this.WindowClosing.Subscribe(v => this.onWindowClosing(v));
		}
	}
}
