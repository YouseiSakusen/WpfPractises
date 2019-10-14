using Prism.Mvvm;
using Reactive.Bindings;

namespace WpfPrism72
{
	/// <summary>BLEACHキャラクターを表します。</summary>
	public class BleachCharacter
	{
		#region プロパティ

		/// <summary>BLEACHキャラクターコードを取得します。</summary>
		public ReactiveProperty<string> Code { get; }

		/// <summary>キャラクター名を取得・設定します。</summary>
		public ReactivePropertySlim<string> Name { get; set; }

		/// <summary>キャラクター名読み仮名を取得・設定します。</summary>
		public ReactivePropertySlim<string> Yomigana { get; set; }

		/// <summary>斬魄刀銘を取得・設定します。</summary>
		public ReactivePropertySlim<string> Zanpakuto { get; set; }

		/// <summary>卍解名を取得・設定します。</summary>
		public ReactivePropertySlim<string> Bankai { get; set; }

		#endregion

		#region メソッド

		/// <summary>BleachCharacterの値を設定します。</summary>
		/// <param name="source">値の設定元を表すBleachCharacter。</param>
		public void SetCharacter(BleachCharacter source)
		{
			this.Code.Value = source.Code.Value;
			this.Name.Value = source.Name.Value;
			this.Yomigana.Value = source.Yomigana.Value;
			this.Zanpakuto.Value = source.Zanpakuto.Value;
			this.Bankai.Value = source.Bankai.Value;
		}

		/// <summary>全てのプロパティを初期化します。</summary>
		public void ClearValues()
		{
			this.Code.Value = string.Empty;
			this.Name.Value = string.Empty;
			this.Yomigana.Value = string.Empty;
			this.Zanpakuto.Value = string.Empty;
			this.Bankai.Value = string.Empty;
		}

		///// <summary>キャラクターコードのChangeイベントハンドラ。</summary>
		///// <param name="code">キャラクターコードを表す文字列。</param>
		//private void onChangeCode(string code)
		//{
		//	if (this.isInitializing)
		//		return;

		//	if (string.IsNullOrEmpty(code))
		//	{
		//		this.Name.Value = string.Empty;
		//		return;
		//	}

		//	var chara = new BleachAgent().GetCharacter(code);
		//	if (chara == null)
		//		this.Code.Value = string.Empty;
		//	else
		//		this.Name.Value = chara.Name.Value;
		//}

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
			this.Name = new ReactivePropertySlim<string>(string.Empty);
			this.Code = new ReactiveProperty<string>(string.Empty);
			//this.Code.Where(c => c.Length == 0 || c.Length == 3)
			//	.Subscribe(c => this.onChangeCode(c));

			this.Yomigana = new ReactivePropertySlim<string>(string.Empty);
			this.Zanpakuto = new ReactivePropertySlim<string>(string.Empty);
			this.Bankai = new ReactivePropertySlim<string>(string.Empty);
		}

		#endregion
	}
}
