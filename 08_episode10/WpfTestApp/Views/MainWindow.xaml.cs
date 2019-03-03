using System.Diagnostics;
using System.ComponentModel;
using System.Windows;

namespace WpfTestApp.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public bool CancelClose
		{
			get { return (bool)GetValue(CancelCloseProperty); }
			set { SetValue(CancelCloseProperty, value); }
		}

		// Using a DependencyProperty as the backing store for CancelClose.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CancelCloseProperty =
			DependencyProperty.Register(nameof(MainWindow.CancelClose), typeof(bool), typeof(MainWindow), new PropertyMetadata(false));

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);

			Debug.WriteLine(this.CancelClose);
		}

		public MainWindow()
		{
			InitializeComponent();
		}
	}
}
