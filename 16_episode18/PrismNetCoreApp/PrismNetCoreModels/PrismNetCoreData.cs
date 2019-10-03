using System.Runtime.Serialization;

namespace PrismNetCoreApp
{
	[DataContract]
	public class PrismNetCoreData : IPrismNetCoreData
	{
		#region プロパティ

		[DataMember]
		public PersonalInformation TargetPerson { get; set; } = null;

		#endregion

		#region コンストラクタ

		public PrismNetCoreData(PersonalInformation person) : this()
			=> this.TargetPerson = person;

		public PrismNetCoreData() : base() { }

		#endregion
	}
}
