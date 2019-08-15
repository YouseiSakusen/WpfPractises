using System.Diagnostics;
using Prism.Mvvm;

namespace VmLoadTest.ViewModels
{
	public class ViewBViewModel : BindableBase
	{
		public ViewBViewModel()
		{
			Debug.WriteLine("ViewB loaded");
		}
	}
}
