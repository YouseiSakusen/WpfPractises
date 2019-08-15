using System.Diagnostics;
using Prism.Mvvm;

namespace VmLoadTest.ViewModels
{
	public class ViewAViewModel : BindableBase
	{
		public ViewAViewModel()
		{
			Debug.WriteLine("ViewA loaded");
		}
	}
}
