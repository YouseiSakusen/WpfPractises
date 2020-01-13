using System.Linq;

namespace WpfTestApp
{
	/// <summary>サンプルアプリのデータコンテナを表します。</summary>
	[System.Runtime.Serialization.DataContract]
	public class WpfTestAppData
	{
		#region "プロパティ"

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

		#endregion

		/// <summary>新規データを作成します。</summary>
		/// <typeparam name="T">作成するデータの型を表します。</typeparam>
		/// <returns>作成した新規データを表すT。</returns>
		public T CreateNewData<T>() where T: class
		{
			if (typeof(T) == typeof(PhysicalInformation))
			{
				var id = (this.getMaxPhysicalId()) + 1;
				return new PhysicalInformation() { Id = id } as T;
			}

			if (typeof(T) == typeof(TestPointInformation))
			{
				var id = (this.getMaxTestPointId()) + 1;

				return new TestPointInformation()
				{
					Id = id,
					TestDate = "新しい試験日"
				} as T;
			}

			return null;
		}

		/// <summary>身体測定データIDの最大値を取得します。</summary>
		/// <returns>身体測定データIDの最大値を表すint。</returns>
		private int getMaxPhysicalId()
		{
			if (this.Physicals.Count == 0) { return 0; }

			return this.Physicals.Max(p => p.Id);
		}

		/// <summary>試験結果データIDの最大値を取得します。</summary>
		/// <returns>試験結果データIDの最大値を表すint。</returns>
		private int getMaxTestPointId()
		{
			if (this.TestPoints.Count == 0) { return 0; }

			return this.TestPoints.Max(p => p.Id);
		}
	}
}
