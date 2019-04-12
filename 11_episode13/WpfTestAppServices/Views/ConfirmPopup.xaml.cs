using System;
using System.Windows.Controls;
using Prism.Interactivity.InteractionRequest;

namespace WpfTestApp.Views
{
	/// <summary>
	/// Interaction logic for ConfirmPopup
	/// </summary>
	public partial class ConfirmPopup : UserControl, IInteractionRequestAware
	{
		private IConfirmation confirmation;

		/// <summary>Prismとやり取りするINotificationインタフェースを取得・設定します。</summary>
		public INotification Notification
		{
			get { return this.confirmation; }
			set { this.confirmation = (IConfirmation)value; }
		}

		/// <summary>終了処理を表すActionを取得・設定します。。</summary>
		public Action FinishInteraction { get; set; }

		/// <summary>はいボタンのイベントハンドラ</summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを表すRoutedEventArgs。</param>
		private void YesButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.confirmation.Confirmed = true;
			this.FinishInteraction?.Invoke();
		}

		/// <summary>いいえボタンのイベントハンドラ</summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを表すRoutedEventArgs。</param>
		private void NoButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.confirmation.Confirmed = false;
			this.FinishInteraction?.Invoke();
		}

		/// <summary>コンストラクタ。</summary>
		public ConfirmPopup()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{

		}
	}
}
