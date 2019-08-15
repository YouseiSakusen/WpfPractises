using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;

namespace WpfTestApp
{
	public class BleachAgent
	{
		public Character GetCharacter(string characterCode)
		{
			return BleachAgent.characters.Find(c => c.Code.Value == characterCode);
		}

		public List<Character> GetAllCharacters()
		{
			return BleachAgent.characters;
		}

		private static List<Character> characters { get; set; } = null;

		public static ReactiveCollection<Character> charaCol { get; set; }

		private void initCharacters()
		{
			if (BleachAgent.characters != null)
				return;

			BleachAgent.characters = new List<Character>();

			BleachAgent.characters.Add(new Character("001", "黒崎一護", "くろさき いちご", "斬月", "天鎖斬月"));
			BleachAgent.characters.Add(new Character("131", "朽木ルキア", "くちき るきあ", "袖白雪", "白霞罸"));
			BleachAgent.characters.Add(new Character("061", "阿散井恋次", "あばらい れんじ", "蛇尾丸", "狒狒王蛇尾丸"));
			BleachAgent.characters.Add(new Character("120", "浦原喜助", "うらはら きすけ", "紅姫", "観音開紅姫改メ"));
			BleachAgent.characters.Add(new Character("060", "朽木白哉", "くちき びゃくや", "千本桜", "千本桜景厳"));
			BleachAgent.characters.Add(new Character("100", "日番谷冬獅郎", "ひつがや とうしろう", "氷輪丸", "大紅蓮氷輪丸"));
			BleachAgent.characters.Add(new Character("110", "更木剣八", "ざらき けんぱち", "野晒", "-"));
			BleachAgent.characters.Add(new Character("121", "涅マユリ", "くろつち まゆり", "疋殺地蔵", "金色疋殺地蔵"));
			BleachAgent.characters.Add(new Character("011", "京楽 春水", "きょうらく しゅんすい", "花天狂骨", "花天狂骨枯松心中"));
			BleachAgent.characters.Add(new Character("010", "山本 元柳斎 重國", "やまもと げんりゅうさい しげくに", "流刃若火", "残火の太刀"));
			BleachAgent.characters.Add(new Character("020", "砕蜂", "そい ふぉん", "雀蜂", "雀蜂雷公鞭"));
			BleachAgent.characters.Add(new Character("040", "卯ノ花 烈", "うのはな れつ", "肉雫唼", "皆尽"));
			BleachAgent.characters.Add(new Character("050", "平子 真子", "ひらこ しんじ", "逆撫", "逆様邪八宝塞"));
			BleachAgent.characters.Add(new Character("130", "浮竹 十四郎", "うきたけ じゅうしろう", "双魚理", "-"));
		}

		public BleachAgent()
		{
			this.initCharacters();
		}
	}
}
