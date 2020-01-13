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
