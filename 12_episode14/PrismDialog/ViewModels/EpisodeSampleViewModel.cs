using System.Collections.ObjectModel;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace WpfTestApp.ViewModels
{
	public class EpisodeSampleViewModel : BindableBase
	{
		// ReadOnly無しのReactiveProperty
		public ReactiveProperty<string> Name { get; set; }
		public ReactiveCollection<int> Numbers { get; }

		// ReadOnly付きのReactiveProperty
		public ReadOnlyReactiveProperty<string> NickName { get; }
		public ReadOnlyReactiveCollection<Character> Characters { get; }


		private string nickNameSource = string.Empty;
		private ObservableCollection<Character> charaList = null;

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
			this.charaList = new ObservableCollection<Character>(new BleachAgent().GetAllCharacters());
			this.Characters = this.charaList
				.ToReadOnlyReactiveCollection();
		}
	}
}
