using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;

namespace WpfTestApp
{
	public class SampleItem
	{
		public ReactivePropertySlim<string> Code { get; set; }

		public SampleItem()
		{
			this.Code = new ReactivePropertySlim<string>(string.Empty);
		}
	}
}
