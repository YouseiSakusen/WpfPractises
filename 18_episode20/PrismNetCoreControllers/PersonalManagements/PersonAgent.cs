using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PrismNetCoreApp
{
	public static class PersonAgent
	{
		#region メソッド

		private static List<PersonalInformation> persons = new List<PersonalInformation>();

		public static List<PersonalInformation> GetAllPersons()
		{
			if (PersonAgent.persons.Count == 0)
				PersonAgent.initializePersons();

			return PersonAgent.persons;
		}

		private static void initializePersons()
		{
			PersonAgent.persons.Add(new PersonalInformation("001", "黒崎一護", "くろさき いちご", "死神代行", "斬月", "天鎖斬月"));
			PersonAgent.persons.Add(new PersonalInformation("131", "朽木ルキア", "くちき るきあ", "十三番隊", "袖白雪", "白霞罸"));
			PersonAgent.persons.Add(new PersonalInformation("061", "阿散井恋次", "あばらい れんじ", "六番隊", "蛇尾丸", "狒狒王蛇尾丸"));
			PersonAgent.persons.Add(new PersonalInformation("120", "浦原喜助", "うらはら きすけ", "浦原商店", "紅姫", "観音開紅姫改メ"));
			PersonAgent.persons.Add(new PersonalInformation("060", "朽木白哉", "くちき びゃくや", "六番隊", "千本桜", "千本桜景厳"));
			PersonAgent.persons.Add(new PersonalInformation("100", "日番谷冬獅郎", "ひつがや とうしろう", "十番隊", "氷輪丸", "大紅蓮氷輪丸"));
			PersonAgent.persons.Add(new PersonalInformation("110", "更木剣八", "ざらき けんぱち", "十一番隊", "野晒", "-"));
			PersonAgent.persons.Add(new PersonalInformation("121", "涅マユリ", "くろつち まゆり", "十二番隊", "疋殺地蔵", "金色疋殺地蔵"));
			PersonAgent.persons.Add(new PersonalInformation("011", "京楽春水", "きょうらく しゅんすい", "一番隊", "花天狂骨", "花天狂骨枯松心中"));
			PersonAgent.persons.Add(new PersonalInformation("010", "山本元柳斎重國", "やまもと げんりゅうさい しげくに", "一番隊", "流刃若火", "残火の太刀"));
			PersonAgent.persons.Add(new PersonalInformation("020", "砕蜂", "そい ふぉん", "二番隊", "雀蜂", "雀蜂雷公鞭"));
			PersonAgent.persons.Add(new PersonalInformation("040", "卯ノ花烈", "うのはな れつ", "四番隊", "肉雫唼", "皆尽"));
			PersonAgent.persons.Add(new PersonalInformation("050", "平子真子", "ひらこ しんじ", "五番隊", "逆撫", "逆様邪八宝塞"));
			PersonAgent.persons.Add(new PersonalInformation("130", "浮竹 十四郎", "うきたけ じゅうしろう", "十三番隊", "双魚理", "-"));
		}

		#endregion
	}
}
