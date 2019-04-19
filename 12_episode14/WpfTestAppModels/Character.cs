using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;

namespace WpfTestApp
{
	public class Character
	{
		public ReactivePropertySlim<string> Code { get; }

		public ReactivePropertySlim<string> Name { get; set; }

		public ReactivePropertySlim<string> Yomigana { get; set; }

		public ReactivePropertySlim<string> Zanpakuto { get; set; }

		public ReactivePropertySlim<string> Bankai { get; set; }

		public Character(string code, string name, string yomi, string swordName, string bankai) : this()
		{
			this.Code.Value = code;
			this.Name.Value = name;
			this.Yomigana.Value = yomi;
			this.Zanpakuto.Value = swordName;
			this.Bankai.Value = bankai;
		}

		public Character()
		{
			this.Code = new ReactivePropertySlim<string>(string.Empty);
			this.Name = new ReactivePropertySlim<string>(string.Empty);
			this.Yomigana = new ReactivePropertySlim<string>(string.Empty);
			this.Zanpakuto = new ReactivePropertySlim<string>(string.Empty);
			this.Bankai = new ReactivePropertySlim<string>(string.Empty);
		}
	}
}
