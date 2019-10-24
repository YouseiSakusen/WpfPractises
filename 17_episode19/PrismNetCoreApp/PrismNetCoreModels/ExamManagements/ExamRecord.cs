using System;
using System.Runtime.Serialization;
using Reactive.Bindings;

namespace PrismNetCoreApp.ExamManagements
{
	[DataContract]
	public class ExamRecord : PersonalRecord
	{
		#region プロパティ

		[DataMember]
		public ReactivePropertySlim<string> TestDate { get; set; }

		[DataMember]
		public ReactivePropertySlim<int> JapaneseScore { get; set; }

		[DataMember]
		public ReactivePropertySlim<int> MathematicsScore { get; set; }

		[DataMember]
		public ReactivePropertySlim<int> EnglishScore { get; set; }

		public ReadOnlyReactivePropertySlim<decimal> AverageScore { get; }

		#endregion

		#region privateメソッド

		private void setAverage()
		{
			var total = this.JapaneseScore.Value + this.MathematicsScore.Value + this.EnglishScore.Value;

			this.average.Value = Math.Round((decimal)(total / 3), 2, MidpointRounding.AwayFromZero);
		}

		#endregion

		#region コンストラクタ

		private ReactivePropertySlim<decimal> average;

		public ExamRecord() : base()
		{
			this.TestDate = new ReactivePropertySlim<string>(string.Empty);
			this.JapaneseScore = new ReactivePropertySlim<int>(0);
			this.MathematicsScore = new ReactivePropertySlim<int>(0);
			this.EnglishScore = new ReactivePropertySlim<int>(0);

			this.average = new ReactivePropertySlim<decimal>(0);

			this.TestDate.Subscribe(_ => this.setAverage());
			this.JapaneseScore.Subscribe(_ => this.setAverage());
			this.MathematicsScore.Subscribe(_ => this.setAverage());
			this.EnglishScore.Subscribe(_ => this.setAverage());

			this.AverageScore = new ReadOnlyReactivePropertySlim<decimal>(this.average);
		}

		#endregion
	}
}
