using Prism.Mvvm;
using Prism.Regions;

namespace WpfTestApp.ViewModels
{
	public class PersonalEditorViewModel : BindableBase, INavigationAware
	{
		/// <summary>生徒氏名を取得・設定します。</summary>
		private string _name;
		public string Name
		{
			get { return _name; }
			set { SetProperty(ref _name, value); }
		}

		/// <summary>所属クラスを取得・設定します。</summary>
		private string classNum;
		public string ClassNumber
		{
			get { return classNum; }
			set { SetProperty(ref classNum, value); }
		}

		/// <summary>性別を取得・設定します。</summary>
		private string _sex;
		public string Sex
		{
			get { return _sex; }
			set { SetProperty(ref _sex, value); }
		}

		/// <summary>コンストラクタ。</summary>
		public PersonalEditorViewModel() { }

		private PersonalInformation personInfo = null;

		/// <summary>Viewを表示した後呼び出されます。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
		{
			this.personInfo = navigationContext.Parameters["TargetData"] as PersonalInformation;

			this.Name = this.personInfo.Name;
			this.ClassNumber = this.personInfo.ClassNumber;
			this.Sex = this.personInfo.Sex;
		}

		/// <summary>表示するViewを判別します。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		/// <returns>表示するViewかどうかを表すbool。</returns>
		bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext) { return true; }

		/// <summary>別のViewに切り替わる前に呼び出されます。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.personInfo.Name = this.Name;
			this.personInfo.ClassNumber = this.ClassNumber;
			this.personInfo.Sex = this.Sex;
		}
	}
}
