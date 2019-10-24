using System;
using System.Runtime.Serialization;
using Reactive.Bindings;

namespace PrismNetCoreApp.PhysicalManagements
{
	[DataContract]
	public class PhysicalRecord : PersonalRecord
	{
		#region プロパティ

		[DataMember]
		public ReactivePropertySlim<DateTime?> MeasurementDate { get; set; }

		[DataMember]
		public ReactivePropertySlim<decimal> Height { get; set; }

		[DataMember]
		public ReactivePropertySlim<decimal> Weight { get; set; }

		public ReadOnlyReactivePropertySlim<decimal> Bmi { get; }

		#endregion

		#region privateメソッド

		private void setBmi()
		{
			if (this.Height.Value == 0)
				return;

			var height = (double)this.Weight.Value;
			var weight = (double)this.Height.Value;
			var value = (decimal)(weight / Math.Pow((height / 100), 2));

			this.bmi.Value = Math.Round(value, 2, MidpointRounding.AwayFromZero);
		}

		#endregion

		#region コンストラクタ

		private ReactivePropertySlim<decimal> bmi;

		public PhysicalRecord() : base()
		{
			this.MeasurementDate = new ReactivePropertySlim<DateTime?>(null);
			this.Height = new ReactivePropertySlim<decimal>(0);
			this.Weight = new ReactivePropertySlim<decimal>(0);

			this.bmi = new ReactivePropertySlim<decimal>(0);

			this.Height.Subscribe(_ => this.setBmi());
			this.Weight.Subscribe(_ => this.setBmi());
		}

		#endregion
	}
}
