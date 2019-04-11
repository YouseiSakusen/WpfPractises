using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestApp
{
	public class BleachAgent
	{
		public List<Character> GetAllCharacters()
		{
			return this.characters;
		}

		private List<Character> characters { get; set; }

		private void initCharacters()
		{
			var charaList = new List<Character>();

			charaList.Add(new Character("001", "黒崎一護", "くろさき いちご", "斬月", "天鎖斬月"));
			charaList.Add(new Character("131", "朽木ルキア", "くちき るきあ", "袖白雪", "白霞罸"));
			charaList.Add(new Character("061", "阿散井恋次", "あばらい れんじ", "蛇尾丸", "狒狒王蛇尾丸"));
			charaList.Add(new Character("120", "浦原喜助", "うらはら きすけ", "紅姫", "観音開紅姫改メ"));
			charaList.Add(new Character("060", "朽木白哉", "くちき びゃくや", "千本桜", "千本桜景厳"));
			charaList.Add(new Character("100", "日番谷冬獅郎", "ひつがや とうしろう", "氷輪丸", "大紅蓮氷輪丸"));
			charaList.Add(new Character("110", "更木剣八", "ざらき けんぱち", "野晒", "-"));
			charaList.Add(new Character("121", "涅マユリ", "くろつち まゆり", "疋殺地蔵", "金色疋殺地蔵"));
			charaList.Add(new Character("011", "京楽 春水", "きょうらく しゅんすい", "花天狂骨", "花天狂骨枯松心中"));
			charaList.Add(new Character("010", "山本 元柳斎 重國", "やまもと げんりゅうさい しげくに", "流刃若火", "残火の太刀"));
			charaList.Add(new Character("020", "砕蜂", "そい ふぉん", "雀蜂", "雀蜂雷公鞭"));
			charaList.Add(new Character("040", "卯ノ花 烈", "うのはな れつ", "肉雫唼", "皆尽"));
			charaList.Add(new Character("050", "平子 真子", "ひらこ しんじ", "逆撫", "逆様邪八宝塞"));
			charaList.Add(new Character("130", "浮竹 十四郎", "うきたけ じゅうしろう", "双魚理", "-"));

			this.characters = charaList.OrderBy(c => c.Code.Value).ToList();
		}

		public BleachAgent()
		{
			this.initCharacters();
		}
	}
}
