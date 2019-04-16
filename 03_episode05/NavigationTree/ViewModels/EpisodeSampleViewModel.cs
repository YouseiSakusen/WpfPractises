using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Collections.ObjectModel;

namespace WpfTestApp.ViewModels
{
	public class EpisodeSampleViewModel : BindableBase
	{
		// ReadOnly無しのReactiveProperty
		public ReactiveProperty<string> Name { get; set; }
		public ReactiveCollection<int> Numbers { get; }

		// ReadOnly付きのReactiveProperty
		public ReadOnlyReactiveProperty<string> NickName { get; }
		public ReadOnlyReactiveCollection<PersonalInformation> Persons { get; }
		public ReadOnlyReactiveCollection<PhysicalInformation> PhysicalInformations { get; }

		private string nickNameSource = string.Empty;
		private ObservableCollection<PersonalInformation> personList = null;
		private ReactiveCollection<PhysicalInformation> physicals { get; set; }

		public EpisodeSampleViewModel()
		{
			// ReadOnlyでないReactivePropertyは変数のように扱える
			this.Name = new ReactiveProperty<string>(string.Empty);
			this.Numbers = new ReactiveCollection<int>() { 0, 1, 2 };

			// ReadOnlyのReactivePropertyは必ずソースオブジェクトが必要
			this.NickName = this.ObserveProperty(x => x.nickNameSource)
				.ToReadOnlyReactiveProperty();

			// つまり、以下のような初期化はできない
			//this.NickName = new ReadOnlyReactiveProperty<string>("テスト");


			// この場合の初期化時パラメータにはIObservable<string>が必要と言うエラーになるので
			// ソースにする変数は必須。

			// ReadOnlyReactiveCollectionのソースにはObservableCollectionか
			// ReactiveCollectionから作成するのが楽。
			this.personList = new ObservableCollection<PersonalInformation>();
			this.personList.Add(new PersonalInformation() { Name = "テスト1" });
			this.personList.Add(new PersonalInformation() { Name = "テスト2" });
			this.personList.Add(new PersonalInformation() { Name = "テスト3" });

			this.Persons = this.personList
				.ToReadOnlyReactiveCollection();

			this.physicals = new ReactiveCollection<PhysicalInformation>();
			this.physicals.Add(new PhysicalInformation() { Id = 0 });
			this.physicals.Add(new PhysicalInformation() { Id = 1 });

			this.PhysicalInformations = this.physicals
				.ToReadOnlyReactiveCollection();
		}
	}
}
