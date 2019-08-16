using System;
using System.Collections.ObjectModel;

namespace MvvmSampleApp
{
	public interface ISampleAppData : IDisposable
	{
		#region プロパティ

		ObservableCollection<string> WatchedFiles { get; }

		ObservableCollection<int> Stocks { get; }

		#endregion

		#region メソッド

		void AddToClipboard(int value);

		#endregion
	}
}
