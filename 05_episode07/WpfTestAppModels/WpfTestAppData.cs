using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestApp
{
	[System.Runtime.Serialization.DataContract]
	public class WpfTestAppData
	{
		/// <summary>生徒の情報を取得・設定します。</summary>
		[System.Runtime.Serialization.DataMember]
		public PersonalInformation Student { get; set; } = new PersonalInformation();

		/// <summary>身体測定データを取得します。</summary>
		[System.Runtime.Serialization.DataMember]
		public System.Collections.ObjectModel.ObservableCollection<PhysicalInformation> Physicals { get; private set; }
			= new System.Collections.ObjectModel.ObservableCollection<PhysicalInformation>();

		/// <summary>試験結果データを取得します。</summary>
		[System.Runtime.Serialization.DataMember]
		public System.Collections.ObjectModel.ObservableCollection<TestPointInformation> TestPoints { get; private set; }
			= new System.Collections.ObjectModel.ObservableCollection<TestPointInformation>();
	}
}
