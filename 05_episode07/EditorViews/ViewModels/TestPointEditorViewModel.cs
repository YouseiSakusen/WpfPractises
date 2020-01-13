using System;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace WpfTestApp.ViewModels
{
	/// <summary> 試験結果データの編集画面を表します。 </summary>
	public class TestPointEditorViewModel : BindableBase, IDisposable, INavigationAware
	{
		#region "プロパティ"

		/// <summary>試験日を取得・設定します。</summary>
		public ReactiveProperty<string> TestDate { get; set; }

		/// <summary>国語の点数を取得・設定します。</summary>
		public ReactiveProperty<int> JapaneseScore { get; set; }

		/// <summary>数学の点数を取得・設定します。</summary>
		public ReactiveProperty<int> MathematicsScore { get; set; }

		/// <summary>英語の点数を取得・設定します。</summary>
		public ReactiveProperty<int> EnglishScore { get; set; }

		/// <summary>平均点を取得します。</summary>
		public ReadOnlyReactivePropertySlim<double> Average { get; private set; }

		#endregion

		/// <summary>表示するViewを判別します。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		/// <returns>表示するViewかどうかを表すbool。</returns>
		bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext){ return true; }

		private TestPointInformation testPoint = null;
		private System.Reactive.Disposables.CompositeDisposable disposables =
			new System.Reactive.Disposables.CompositeDisposable();

		/// <summary>Viewを表示した後呼び出されます。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
		{
			if (this.testPoint != null)
				return;
			this.testPoint = navigationContext.Parameters["TargetData"] as TestPointInformation;

			this.TestDate = this.testPoint
				.ToReactivePropertyAsSynchronized(x => x.TestDate)
				.AddTo(this.disposables);
			this.JapaneseScore = this.testPoint
				.ToReactivePropertyAsSynchronized(x => x.JapaneseScore)
				.AddTo(this.disposables);
			this.MathematicsScore = this.testPoint
				.ToReactivePropertyAsSynchronized(x => x.MathematicsScore)
				.AddTo(this.disposables);
			this.EnglishScore = this.testPoint
				.ToReactivePropertyAsSynchronized(x => x.EnglishScore)
				.AddTo(this.disposables);
			this.Average = this.testPoint.ObserveProperty(x => x.Average)
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			this.RaisePropertyChanged(nameof(this.TestDate));
			this.RaisePropertyChanged(nameof(this.JapaneseScore));
			this.RaisePropertyChanged(nameof(this.MathematicsScore));
			this.RaisePropertyChanged(nameof(this.EnglishScore));
			this.RaisePropertyChanged(nameof(this.Average));
		}

		/// <summary>別のViewに切り替わる前に呼び出されます。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext) { return; }

		/// <summary>コンストラクタ。</summary>
		public TestPointEditorViewModel() { }

		/// <summary>オブジェクトを破棄します。</summary>
		void IDisposable.Dispose() { this.disposables.Dispose(); }
	}
}
