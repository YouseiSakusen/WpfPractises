using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestApp
{
	[System.Runtime.Serialization.DataContract]
	public class PersonalInformation : Prism.Mvvm.BindableBase
	{
		private string personName = string.Empty;
		/// <summary>個人名を取得・設定します。</summary>
		[System.Runtime.Serialization.DataMember]
		public string Name
		{
			get { return personName; }
			set { SetProperty(ref personName, value); }
		}

		private string classNum = string.Empty;
		/// <summary>所属クラスを取得・設定します。</summary>
		[System.Runtime.Serialization.DataMember]
		public string ClassNumber
		{
			get { return classNum; }
			set { SetProperty(ref classNum, value); }
		}

		private string sex = string.Empty;
		/// <summary>性別を取得・設定します。</summary>
		[System.Runtime.Serialization.DataMember]
		public string Sex
		{
			get { return sex; }
			set { SetProperty(ref sex, value); }
		}
	}
}
