using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using PrismNetCoreApp.ExamManagements;
using PrismNetCoreApp.PhysicalManagements;
using Reactive.Bindings;

namespace PrismNetCoreApp
{
	public class PersonalInformation : PersonalRecord
	{
		#region プロパティ

		[DataMember]
		public ReactivePropertySlim<string> Name { get; set; }

		[DataMember]
		public ReactivePropertySlim<string> ClassName { get; set; }

		[DataMember]
		public ReactivePropertySlim<string> Sex { get; set; }

		[DataMember]
		public ObservableCollection<ExamRecord> ExsamResults { get; set; }

		[DataMember]
		public ObservableCollection<PhysicalRecord> Physicals { get; set; }

		#endregion

		#region コンストラクタ

		public PersonalInformation() : base()
		{
			this.Name = new ReactivePropertySlim<string>(string.Empty);
			this.ClassName = new ReactivePropertySlim<string>(string.Empty);
			this.Sex = new ReactivePropertySlim<string>(string.Empty);

			this.ExsamResults = new ObservableCollection<ExamRecord>();
			this.Physicals = new ObservableCollection<PhysicalRecord>();
		}

		public PersonalInformation(string personName) : this()
		{
			this.Name.Value = personName;
		}

		#endregion
	}
}
