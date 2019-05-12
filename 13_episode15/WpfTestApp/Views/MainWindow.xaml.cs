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
		public bool WindowClosing
		{
			get { return (bool)GetValue(WindowClosingProperty); }
			set { SetValue(WindowClosingProperty, value); }
		}

		// Using a DependencyProperty as the backing store for WindowClosing.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty WindowClosingProperty =
			DependencyProperty.Register(nameof(MainWindow.WindowClosing), typeof(bool), typeof(MainWindow), new PropertyMetadata(false));

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			this.WindowClosing = true;

			if (!this.WindowClosing)
				e.Cancel = true;
		}

		public MainWindow()
		{
			InitializeComponent();
		}
	}
}
