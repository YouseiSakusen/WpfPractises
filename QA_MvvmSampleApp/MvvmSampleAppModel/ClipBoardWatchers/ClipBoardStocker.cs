using System.Collections.ObjectModel;

namespace MvvmSampleApp.ClipBoardWatchers
{
	public class ClipBoardStocker
	{
		#region プロパティ

		public ObservableCollection<int> Stocks { get; } = new ObservableCollection<int>();

		#endregion

		#region メソッド

		public void Add(int value)
		{
			this.Stocks.Add(value);
		}

		#endregion
	}
}
