using Reactive.Bindings;

namespace WpfPrism72
{
	/// <summary>BLEACHキャラクターを表します。</summary>
	public class BleachCharacter
	{
		#region プロパティ

		/// <summary>BLEACHキャラクターコードを取得します。</summary>
		public ReactivePropertySlim<string> Code { get; }

		/// <summary>キャラクター名を取得・設定します。</summary>
		public ReactivePropertySlim<string> Name { get; set; }

		/// <summary>キャラクター名読み仮名を取得・設定します。</summary>
		public ReactivePropertySlim<string> Yomigana { get; set; }

		/// <summary>斬魄刀銘を取得・設定します。</summary>
		public ReactivePropertySlim<string> Zanpakuto { get; set; }

		/// <summary>卍解名を取得・設定します。</summary>
		public ReactivePropertySlim<string> Bankai { get; set; }

		#endregion

		#region コンストラクタ

		/// <summary>コンストラクタ。</summary>
		/// <param name="code">BLEACHキャラクターコードを表す文字列。</param>
		/// <param name="name">キャラクター名を表す文字列。</param>
		/// <param name="yomi">キャラクター名読み仮名を表す文字列。</param>
		/// <param name="swordName">斬魄刀銘を表す文字列。</param>
		/// <param name="bankai">卍解名を表す文字列。</param>
		public BleachCharacter(string code, string name, string yomi, string swordName, string bankai) : this()
		{
			this.Code.Value = code;
			this.Name.Value = name;
			this.Yomigana.Value = yomi;
			this.Zanpakuto.Value = swordName;
			this.Bankai.Value = bankai;
		}

		/// <summary>デフォルトコンストラクタ。</summary>
		public BleachCharacter()
		{
			this.Code = new ReactivePropertySlim<string>(string.Empty);
			this.Name = new ReactivePropertySlim<string>(string.Empty);
			this.Yomigana = new ReactivePropertySlim<string>(string.Empty);
			this.Zanpakuto = new ReactivePropertySlim<string>(string.Empty);
			this.Bankai = new ReactivePropertySlim<string>(string.Empty);
		}

		#endregion
	}
}
