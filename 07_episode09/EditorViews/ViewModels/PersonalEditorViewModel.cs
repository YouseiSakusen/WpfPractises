using System.ComponentModel.DataAnnotations;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace WpfTestApp.ViewModels
{
	public class PersonalEditorViewModel : BindableBase, INavigationAware
	{
		/// <summary>生徒氏名を取得・設定します。</summary>
		[Required(ErrorMessage = "生徒氏名は必須入力です。")]
		public ReactiveProperty<string> Name { get; set; }

		/// <summary>所属クラスを取得・設定します。</summary>
		public ReactiveProperty<string> ClassNumber { get; set; }

		/// <summary>性別を取得・設定します。</summary>
		public ReactiveProperty<string> Sex { get; set; }

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public PersonalEditorViewModel() { }

		private PersonalInformation personInfo = new PersonalInformation();
		private System.Reactive.Disposables.CompositeDisposable disposables = 
			new System.Reactive.Disposables.CompositeDisposable();

		/// <summary>Viewを表示した後呼び出されます。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
		{
			this.personInfo = navigationContext.Parameters["TargetData"] as PersonalInformation;

			this.Name = this.personInfo
				.ToReactivePropertyAsSynchronized(x => x.Name)
				.SetValidateAttribute(() => this.Name)
				.AddTo(this.disposables);

			this.ClassNumber = this.personInfo
				.ToReactivePropertyAsSynchronized(x => x.ClassNumber)
				.AddTo(this.disposables);

			this.Sex = this.personInfo
				.ToReactivePropertyAsSynchronized(x => x.Sex)
				.AddTo(this.disposables);

			this.RaisePropertyChanged(null);
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
