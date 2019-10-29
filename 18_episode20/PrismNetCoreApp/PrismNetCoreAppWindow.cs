using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using MahApps.Metro.Controls;
using Prism.Services.Dialogs;

namespace PrismNetCoreApp
{
	public class PrismNetCoreAppWindow : MetroWindow, IDialogWindow
	{
		public IDialogResult Result { get; set; }

		private void PersonSelectWindow_Loaded(object sender, RoutedEventArgs e)
		{
			if ((this.DataContext != null) && (this.DataContext is IDialogAware))
				this.Title = (this.DataContext as IDialogAware).Title;

			this.Loaded -= this.PersonSelectWindow_Loaded;
		}

		public PrismNetCoreAppWindow()
		{
			this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;

			this.Loaded += this.PersonSelectWindow_Loaded;
		}
	}
}
