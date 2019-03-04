using Prism.Commands;
using System.Collections.Generic;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations;
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
		[RegularExpression(@"^([1-9]?[0-9]|100)$", ErrorMessage = "国語の得点は 0～100 までの整数を入力してください。")]
		public ReactiveProperty<int> JapaneseScore { get; set; }

		/// <summary>数学の点数を取得・設定します。</summary>
		[RegularExpression(@"^([1-9]?[0-9]|100)$", ErrorMessage = "数学の得点は 0～100 までの整数を入力してください。")]
		public ReactiveProperty<int> MathematicsScore { get; set; }

		/// <summary>英語の点数を取得・設定します。</summary>
		[RegularExpression(@"^([1-9]?[0-9]|100)$", ErrorMessage = "英語の得点は 0～100 までの整数を入力してください。")]
		public ReactiveProperty<int> EnglishScore { get; set; }

		/// <summary>平均点を取得します。</summary>
		public ReadOnlyReactivePropertySlim<double> Average { get; private set; }

		#endregion

		/// <summary>試験日のエラー文字列を取得します。</summary>
		/// <param name="value">View で入力された文字列。</param>
		/// <returns>試験日のエラー文字列</returns>
		private string getTestDateError(string value)
		{
			if (string.IsNullOrEmpty(value))
				return "試験日は必須入力です。";

			if (this.appData.HasTestPointKey(value, this.testPoint))
			{
				this.TestDate.Value = this.testPoint.TestDate;
				return "既に同一の測定日が存在するため、別の日付を設定してください。";
			}

			return null;
		}

		/// <summary>表示するViewを判別します。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		/// <returns>表示するViewかどうかを表すbool。</returns>
		public bool IsNavigationTarget(NavigationContext navigationContext) { return true; }

		private TestPointInformation testPoint = null;
		private System.Reactive.Disposables.CompositeDisposable disposables =
			new System.Reactive.Disposables.CompositeDisposable();

		/// <summary>Viewを表示した後呼び出されます。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			if (this.testPoint != null)
				return;
			this.testPoint = navigationContext.Parameters["TargetData"] as TestPointInformation;

			this.TestDate = this.testPoint
				.ToReactivePropertyAsSynchronized(x => x.TestDate)
				.SetValidateNotifyError(v => this.getTestDateError(v))
				.AddTo(this.disposables);
			this.JapaneseScore = this.testPoint
				.ToReactivePropertyAsSynchronized(x => x.JapaneseScore)
				.SetValidateAttribute(() => this.JapaneseScore)
				.AddTo(this.disposables);
			this.MathematicsScore = this.testPoint
				.ToReactivePropertyAsSynchronized(x => x.MathematicsScore)
				.SetValidateAttribute(() => this.MathematicsScore)
				.AddTo(this.disposables);
			this.EnglishScore = this.testPoint
				.ToReactivePropertyAsSynchronized(x => x.EnglishScore)
				.SetValidateAttribute(() => this.EnglishScore)
				.AddTo(this.disposables);
			this.Average = this.testPoint.ObserveProperty(x => x.Average)
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			this.RaisePropertyChanged(null);
		}

		/// <summary>別のViewに切り替わる前に呼び出されます。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		public void OnNavigatedFrom(NavigationContext navigationContext) { return; }

		private WpfTestAppData appData = null;

		/// <summary>コンストラクタ。</summary>
		public TestPointEditorViewModel(WpfTestAppData testAppData)
		{
			this.appData = testAppData;
		}

		/// <summary>オブジェクトを破棄します。</summary>
		void IDisposable.Dispose() { this.disposables.Dispose(); }
	}
}
