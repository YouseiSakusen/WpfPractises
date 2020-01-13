using System;
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
		public ReactiveProperty<double> Height { get; set; }

		/// <summary>体重を取得・設定します。</summary>
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

		private PhysicalInformation physical = null;	// new PhysicalInformation();
		private System.Reactive.Disposables.CompositeDisposable disposables =
			new System.Reactive.Disposables.CompositeDisposable();

		/// <summary>Viewを表示した後呼び出されます。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
		{
			if (this.physical != null)
				return;

			this.physical = this.getPhysicalData(navigationContext);

			//var physicalInfo = this.getPhysicalData(navigationContext);

			//this.physical.MeasurementDate = physicalInfo.MeasurementDate;
			//this.physical.Height = physicalInfo.Height;
			//this.physical.Weight = physicalInfo.Weight;


			this.MeasurementDate = this.physical
				.ToReactivePropertyAsSynchronized(x => x.MeasurementDate)
				.AddTo(this.disposables);
			this.Height = this.physical
				.ToReactivePropertyAsSynchronized(x => x.Height)
				.AddTo(this.disposables);
			this.Weight = this.physical
				.ToReactivePropertyAsSynchronized(x => x.Weight)
				.AddTo(this.disposables);
			this.Bmi = this.physical.ObserveProperty(x => x.Bmi)
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			this.RaisePropertyChanged(null);
		}

		/// <summary>別のViewに切り替わる前に呼び出されます。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext) { return; }

		/// <summary>コンストラクタ。</summary>
		public PhysicalEditorViewModel()
		{
			//this.MeasurementDate = this.physical
			//	.ToReactivePropertyAsSynchronized(x => x.MeasurementDate)
			//	.AddTo(this.disposables);
			//this.Height = this.physical
			//	.ToReactivePropertyAsSynchronized(x => x.Height)
			//	.AddTo(this.disposables);
			//this.Weight = this.physical
			//	.ToReactivePropertyAsSynchronized(x => x.Weight)
			//	.AddTo(this.disposables);
			//this.Bmi = this.physical.ObserveProperty(x => x.Bmi)
			//	.ToReadOnlyReactivePropertySlim()
			//	.AddTo(this.disposables);
		}

		/// <summary>オブジェクトを破棄します。</summary>
		void IDisposable.Dispose() { this.disposables.Dispose(); }
	}
}
