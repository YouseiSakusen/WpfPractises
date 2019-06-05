using System.Collections.Generic;
using System.Linq;
using Prism.Commands;
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
		private DateTime? measureDate;
		public DateTime? MeasurementDate
		{
			get { return measureDate; }
			set { SetProperty(ref measureDate, value); }
		}

		/// <summary>身長を取得・設定します。</summary>
		private double height;
		public double Height
		{
			get { return height; }
			set
			{
				SetProperty(ref height, value);
				this.calcBmi();
			}
		}

		/// <summary>体重を取得・設定します。</summary>
		private double wight;
		public double Weight
		{
			get { return wight; }
			set
			{
				SetProperty(ref wight, value);
				this.calcBmi();
			}
		}

		/// <summary>BMIを取得します。</summary>
		private double bmi;
		public double Bmi
		{
			get { return bmi; }
			private set { SetProperty(ref bmi, value); }
		}

		/// <summary>BMI を計算します。</summary>
		private void calcBmi()
		{
			if (this.Height == 0)
			{
				this.Bmi = 0;
				return;
			}

			this.Bmi = Math.Round(this.Weight / Math.Pow((this.Height / 100), 2),
								  1,
								  MidpointRounding.AwayFromZero);
		}


		///// <summary>測定日を取得・設定します。</summary>
		//public ReactiveProperty<DateTime?> MeasurementDate { get; set; }

		///// <summary>身長を取得・設定します。</summary>
		//public ReactiveProperty<double> Height { get; set; }

		///// <summary>体重を取得・設定します。</summary>
		//public ReactiveProperty<double> Weight { get; set; }

		///// <summary>BMIを取得します。</summary>
		//public ReadOnlyReactivePropertySlim<double> Bmi { get; private set; }

		#endregion

		/// <summary>表示するViewを判別します。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		/// <returns>表示するViewかどうかを表すbool。</returns>
		bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
		{
			if (this.physical == null)
				return false;

			var physicalInfo = navigationContext.Parameters["TargetData"] as PhysicalInformation;

			return this.physical.Id == physicalInfo.Id;
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
			this.physical = navigationContext.Parameters["TargetData"] as PhysicalInformation;

			this.MeasurementDate = this.physical.MeasurementDate;
			this.Height = this.physical.Height;
			this.Weight = this.physical.Weight;

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

			//this.RaisePropertyChanged(nameof(this.MeasurementDate));
			//this.RaisePropertyChanged(nameof(this.Height));
			//this.RaisePropertyChanged(nameof(this.Weight));
			//this.RaisePropertyChanged(nameof(this.Bmi));
		}

		/// <summary>別のViewに切り替わる前に呼び出されます。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext) { return; }

		/// <summary>コンストラクタ。</summary>
		public PhysicalEditorViewModel(){ }

		/// <summary>オブジェクトを破棄します。</summary>
		void IDisposable.Dispose() { this.disposables.Dispose(); }
	}
}
