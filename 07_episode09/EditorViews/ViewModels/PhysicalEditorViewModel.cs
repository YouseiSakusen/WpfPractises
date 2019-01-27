using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace WpfTestApp.ViewModels
{
	/// <summary> 身体測定データの編集画面を表します。 </summary>
	public class PhysicalEditorViewModel : BindableBase, IDisposable, INavigationAware
	{
		#region "プロパティ"

		/// <summary>測定日を取得・設定します。</summary>
		public ReactiveProperty<DateTime?> MeasurementDate { get; set; }

		/// <summary>身長を取得・設定します。</summary>
		[Display(Name = "身長")]
		[RegularExpression(@"^\d{1,3}(\.\d{1,2})?$",
			ErrorMessage = "{0}は整数3桁 少数2桁の範囲で入力してください。")]
		public ReactiveProperty<double> Height { get; set; }

		/// <summary>体重を取得・設定します。</summary>
		[Display(Name = "体重")]
		[RegularExpression(@"^\d{1,3}(\.\d{1,2})?$",
			ErrorMessage = "{0}は整数3桁 少数2桁の範囲で入力してください。")]
		public ReactiveProperty<double> Weight { get; set; }

		/// <summary>BMIを取得します。</summary>
		public ReadOnlyReactivePropertySlim<double> Bmi { get; private set; }

		#endregion

		/// <summary>身体測定データを取得します。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		/// <returns>NavigationContextから取得したPhysicalInformation。</returns>
		private PhysicalInformation getPhysicalData(NavigationContext navigationContext)
		{
			return navigationContext.Parameters["TargetData"] as PhysicalInformation;
		}

		/// <summary>表示するViewを判別します。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		/// <returns>表示するViewかどうかを表すbool。</returns>
		bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
		{
			var physicalDat = this.getPhysicalData(navigationContext);

			return this.physical.Id == physicalDat.Id;
		}

		private PhysicalInformation physical = null;
		private System.Reactive.Disposables.CompositeDisposable disposables =
			new System.Reactive.Disposables.CompositeDisposable();

		/// <summary>Viewを表示した後呼び出されます。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
		{
			if (this.physical != null)
				return;
			this.physical = this.getPhysicalData(navigationContext);

			var mode = ReactivePropertyMode.Default | ReactivePropertyMode.IgnoreInitialValidationError;

			// 測定日
			this.MeasurementDate = this.physical
				.ToReactivePropertyAsSynchronized(x => x.MeasurementDate, mode, true)
				.SetValidateNotifyError(async v => await Task.Run(() => this.getMeasurementDateError(v)))
				.AddTo(this.disposables);
			// 身長
			this.Height = this.physical
				.ToReactivePropertyAsSynchronized(x => x.Height, ignoreValidationErrorValue: true)
				.SetValidateAttribute(() => this.Height)
				.AddTo(this.disposables);
			// 体重
			this.Weight = this.physical
				.ToReactivePropertyAsSynchronized(x => x.Weight, ignoreValidationErrorValue: true)
				.SetValidateAttribute(() => this.Weight)
				.AddTo(this.disposables);
			// BMI
			this.Bmi = this.physical.ObserveProperty(x => x.Bmi)
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			// View へ反映
			this.RaisePropertyChanged(nameof(this.MeasurementDate));
			this.RaisePropertyChanged(nameof(this.Height));
			this.RaisePropertyChanged(nameof(this.Weight));
			this.RaisePropertyChanged(nameof(this.Bmi));
		}

		/// <summary>別のViewに切り替わる前に呼び出されます。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext) { return; }

		/// <summary>測定日のエラー文字列を取得します。</summary>
		/// <param name="value">View で入力されたDateTime?。</param>
		/// <returns>測定日のエラー文字列</returns>
		private string getMeasurementDateError(DateTime? value)
		{
			if (!value.HasValue)
				return "必須入力です。";

			if (this.appData.HasPhysicalKey(value, this.physical))
				return "既に同一の測定日が存在するため、別の日付を設定してください。";
			else
				return null;
		}

		/// <summary>アプリデータ本体を表します。</summary>
		private WpfTestAppData appData = null;

		/// <summary>コンストラクタ。</summary>
		/// <param name="data">アプリのデータオブジェクト（Unity からインジェクション）</param>
		public PhysicalEditorViewModel(WpfTestAppData data) { this.appData = data; }

		/// <summary>オブジェクトを破棄します。</summary>
		void IDisposable.Dispose() { this.disposables.Dispose(); }
	}
}
