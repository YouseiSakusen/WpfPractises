using System.Runtime.Serialization;
using Reactive.Bindings;

namespace PrismNetCoreApp
{
	public class PersonalRecord
	{
		#region プロパティ

		[DataMember]
		public ReactivePropertySlim<int> Id { get; set; }

		#endregion

		#region コンストラクタ

		public PersonalRecord()
		{
			this.Id = new ReactivePropertySlim<int>(0);
		}

		#endregion
	}
}
