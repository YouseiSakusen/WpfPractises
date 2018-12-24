using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace WpfTestApp.ViewModels
{
	public class PersonalEditorViewModel : BindableBase, INavigationAware
	{
		/// <summary>生徒氏名を取得・設定します。</summary>
		public ReactiveProperty<string> Name { get; set; }

		/// <summary>所属クラスを取得・設定します。</summary>
		public ReactiveProperty<string> ClassNumber { get; set; }

		/// <summary>性別を取得・設定します。</summary>
		public ReactiveProperty<string> Sex { get; set; }

		/// <summary>コンストラクタ。</summary>
		public PersonalEditorViewModel() { }

		private PersonalInformation personInfo = null;
		private System.Reactive.Disposables.CompositeDisposable disposables = 
			new System.Reactive.Disposables.CompositeDisposable();

		/// <summary>Viewを表示した後呼び出されます。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
		{
			if (this.personInfo != null)
				return;
			this.personInfo = navigationContext.Parameters["TargetData"] as PersonalInformation;

			this.Name = this.personInfo
				.ToReactivePropertyAsSynchronized(x => x.Name)
				.AddTo(this.disposables);

			this.ClassNumber = this.personInfo
				.ToReactivePropertyAsSynchronized(x => x.ClassNumber)
				.AddTo(this.disposables);

			this.Sex = this.personInfo
				.ToReactivePropertyAsSynchronized(x => x.Sex)
				.AddTo(this.disposables);

			this.RaisePropertyChanged(nameof(this.Name));
			this.RaisePropertyChanged(nameof(this.ClassNumber));
			this.RaisePropertyChanged(nameof(this.Sex));
		}

		/// <summary>表示するViewを判別します。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		/// <returns>表示するViewかどうかを表すbool。</returns>
		bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext) { return true; }

		/// <summary>別のViewに切り替わる前に呼び出されます。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext) { return; }
	}
}
