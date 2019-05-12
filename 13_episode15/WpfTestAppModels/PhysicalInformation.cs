using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestApp
{
	[System.Runtime.Serialization.DataContract]
	public class PhysicalInformation : Prism.Mvvm.BindableBase
	{
		/// <summary>身体測定データのIDを取得・設定します。</summary>
		public int Id { get; set; } = 0;

		private DateTime? measureDate = null;
		/// <summary>測定日を取得・設定します。</summary>
		[System.Runtime.Serialization.DataMember]
		public DateTime? MeasurementDate
		{
			get { return measureDate; }
			set { SetProperty(ref measureDate, value); }
		}

		private double bodyHeight = 0;
		/// <summary>身長を取得・設定します。</summary>
		[System.Runtime.Serialization.DataMember]
		public double Height
		{
			get { return bodyHeight; }
			set
			{
				SetProperty(ref bodyHeight, value);
				this.calcBmi();
			}
		}

		private double bodyWeight = 0;
		/// <summary>体重を取得・設定します。</summary>
		[System.Runtime.Serialization.DataMember]
		public double Weight
		{
			get { return bodyWeight; }
			set
			{
				SetProperty(ref bodyWeight, value);
				this.calcBmi();
			}
		}

		/// <summary>BMI を計算します。</summary>
		private void calcBmi()
		{
			if (this.Height == 0) { return; }

			this.Bmi = Math.Round(this.bodyWeight / Math.Pow((this.bodyHeight / 100), 2),
								  1,
								  MidpointRounding.AwayFromZero);
		}

		private double _bmi = 0;
		/// <summary>BMI値を取得します。</summary>
		[System.Runtime.Serialization.DataMember]
		public double Bmi
		{
			get { return _bmi; }
			private set { SetProperty(ref _bmi, value); }
		}
	}
}
