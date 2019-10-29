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

		/// <summary>個人コードを取得します。</summary>
		[DataMember]
		public ReactiveProperty<string> Code { get; }

		[DataMember]
		public ReactivePropertySlim<string> Name { get; set; }

		/// <summary>名前の読み仮名を取得・設定します。</summary>
		[DataMember]
		public ReactivePropertySlim<string> Yomigana { get; set; }

		[DataMember]
		public ReactivePropertySlim<string> ClassName { get; set; }

		[DataMember]
		public ReactivePropertySlim<string> Sex { get; set; }

		/// <summary>装備を取得・設定します。</summary>
		[DataMember]
		public ReactivePropertySlim<string> Equipment { get; set; }

		/// <summary>特殊能力を取得・設定します。</summary>
		public ReactivePropertySlim<string> SpecialSkill { get; set; }

		[DataMember]
		public ObservableCollection<ExamRecord> ExsamResults { get; set; }

		[DataMember]
		public ObservableCollection<PhysicalRecord> Physicals { get; set; }

		#endregion

		#region コンストラクタ

		public PersonalInformation(string code,
								   string name,
								   string yomi,
								   string className,
								   string equip,
								   string skill) : this()
		{
			this.Code.Value = code;
			this.Name.Value = name;
			this.Yomigana.Value = yomi;
			this.ClassName.Value = className;
			this.Equipment.Value = equip;
			this.SpecialSkill.Value = skill;
		}

		public PersonalInformation() : base()
		{
			this.Code = new ReactiveProperty<string>(string.Empty);
			this.Name = new ReactivePropertySlim<string>(string.Empty);
			this.Yomigana = new ReactivePropertySlim<string>(string.Empty);
			this.ClassName = new ReactivePropertySlim<string>(string.Empty);
			this.Sex = new ReactivePropertySlim<string>(string.Empty);
			this.Equipment = new ReactivePropertySlim<string>(string.Empty);
			this.SpecialSkill = new ReactivePropertySlim<string>(string.Empty);

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
