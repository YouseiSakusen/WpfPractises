using System.Collections.Generic;

namespace WpfPrism72
{
	/// <summary>BLEACHキャラクター用Agentクラスを表します。</summary>
	public class BleachAgent
	{
		/// <summary>BLEACHキャラクターの値を設定します。</summary>
		/// <param name="target">設定先のBleachCharacter。</param>
		public void SetCharacterValues(BleachCharacter target)
		{
			var bleachChara = this.GetCharacter(target.Code.Value);

			if (bleachChara == null)
				target.ClearValues();
			else
				target.SetCharacter(bleachChara);
		}

		/// <summary>キャラクターコードからBLEACHキャラクターを取得します。</summary>
		/// <param name="characterCode">BLEACHキャラクターコードを表す文字列。</param>
		/// <returns>BleachCharacter。</returns>
		public BleachCharacter GetCharacter(string characterCode)
			=> BleachAgent.characters.Find(c => c.Code.Value == characterCode);

		/// <summary>全BLEACHキャラクターを取得します。</summary>
		/// <returns>全BLEACHキャラクターを表すList<BleachCharacter>。</returns>
		public List<BleachCharacter> GetAllCharacters()
			=> BleachAgent.characters;

		/// <summary>BLEACHキャラクターのリストを表します。</summary>
		private static List<BleachCharacter> characters { get; set; } = null;

		/// <summary>BLEACHキャラクターのリストを初期化します。</summary>
		private void initCharacters()
		{
			if (BleachAgent.characters != null)
				return;

			BleachAgent.characters = new List<BleachCharacter>();
			BleachAgent.characters.Add(new BleachCharacter("001", "黒崎一護", "くろさき いちご", "斬月", "天鎖斬月"));
			BleachAgent.characters.Add(new BleachCharacter("131", "朽木ルキア", "くちき るきあ", "袖白雪", "白霞罸"));
			BleachAgent.characters.Add(new BleachCharacter("061", "阿散井恋次", "あばらい れんじ", "蛇尾丸", "狒狒王蛇尾丸"));
			BleachAgent.characters.Add(new BleachCharacter("120", "浦原喜助", "うらはら きすけ", "紅姫", "観音開紅姫改メ"));
			BleachAgent.characters.Add(new BleachCharacter("060", "朽木白哉", "くちき びゃくや", "千本桜", "千本桜景厳"));
			BleachAgent.characters.Add(new BleachCharacter("100", "日番谷冬獅郎", "ひつがや とうしろう", "氷輪丸", "大紅蓮氷輪丸"));
			BleachAgent.characters.Add(new BleachCharacter("110", "更木剣八", "ざらき けんぱち", "野晒", "-"));
			BleachAgent.characters.Add(new BleachCharacter("121", "涅マユリ", "くろつち まゆり", "疋殺地蔵", "金色疋殺地蔵"));
			BleachAgent.characters.Add(new BleachCharacter("011", "京楽 春水", "きょうらく しゅんすい", "花天狂骨", "花天狂骨枯松心中"));
			BleachAgent.characters.Add(new BleachCharacter("010", "山本 元柳斎 重國", "やまもと げんりゅうさい しげくに", "流刃若火", "残火の太刀"));
			BleachAgent.characters.Add(new BleachCharacter("020", "砕蜂", "そい ふぉん", "雀蜂", "雀蜂雷公鞭"));
			BleachAgent.characters.Add(new BleachCharacter("040", "卯ノ花 烈", "うのはな れつ", "肉雫唼", "皆尽"));
			BleachAgent.characters.Add(new BleachCharacter("050", "平子 真子", "ひらこ しんじ", "逆撫", "逆様邪八宝塞"));
			BleachAgent.characters.Add(new BleachCharacter("130", "浮竹 十四郎", "うきたけ じゅうしろう", "双魚理", "-"));
		}

		#region コンストラクタ

		/// <summary>
		/// デフォルトコンストラクタ。
		/// </summary>
		public BleachAgent()
			=> this.initCharacters();

		#endregion
	}
}
