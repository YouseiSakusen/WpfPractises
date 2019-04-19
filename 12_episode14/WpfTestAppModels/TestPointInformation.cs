using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestApp
{
	[System.Runtime.Serialization.DataContract]
	public class TestPointInformation : Prism.Mvvm.BindableBase
	{
		/// <summary>試験結果のIDを取得・設定します。</summary>
		public int Id { get; set; } = 0;

		private string testDay = string.Empty;
		/// <summary>試験日を取得・設定します。</summary>
		[System.Runtime.Serialization.DataMember]
		public string TestDate
		{
			get { return testDay; }
			set { SetProperty(ref testDay, value); }
		}

		private int japanScore = 0;
		/// <summary>国語の得点を取得・設定します。</summary>
		[System.Runtime.Serialization.DataMember]
		public int JapaneseScore
		{
			get { return japanScore; }
			set
			{
				SetProperty(ref japanScore, value);
				this.calcAverage();
			}
		}

		private int mathScore = 0;
		/// <summary>数学の得点を取得・設定します。</summary>
		[System.Runtime.Serialization.DataMember]
		public int MathematicsScore
		{
			get { return mathScore; }
			set
			{
				SetProperty(ref mathScore, value);
				this.calcAverage();
			}
		}

		private int engScore = 0;
		/// <summary>英語の得点を取得・設定します。</summary>
		[System.Runtime.Serialization.DataMember]
		public int EnglishScore
		{
			get { return engScore; }
			set
			{
				SetProperty(ref engScore, value);
				this.calcAverage();
			}
		}

		/// <summary>平均点を計算します。</summary>
		private void calcAverage()
		{
			this.Average = (this.japanScore + this.mathScore + this.engScore) / 3;
		}

		private double ave = 0;
		/// <summary>平均点を取得します。</summary>
		/// [System.Runtime.Serialization.DataMember]
		public double Average
		{
			get { return ave; }
			private set { SetProperty(ref ave, value); }
		}
	}
}
