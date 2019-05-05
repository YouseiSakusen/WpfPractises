using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Interactivity.InteractionRequest;

namespace WpfTestApp
{
	public class MessageBoxService : IMessageBoxService
	{
		/// <summary>MessageBoxを表示します。</summary>
		public InteractionRequest<INotification> MessageBoxRequest { get; }

		/// <summary>確認メッセージボックスを表示します。</summary>
		/// <param name="message">メッセージボックスに表示する内容を表す文字列。</param>
		/// <param name="title">メッセージボックスのタイトルを表す文字列。</param>
		/// <returns>メッセージボックスの選択結果を表すMessageBoxResult列挙型の内の1つ。</returns>
		public MessageBoxResult ShowConfirmMessage(string message, string title)
		{
			var confirm = new Confirmation()
			{
				Content = message,
				Title = title
			};

			var msgRet = MessageBoxResult.Cancel;
			this.MessageBoxRequest.Raise(confirm, r =>
			{
				msgRet = (r as IConfirmation).Confirmed ? MessageBoxResult.OK : MessageBoxResult.Cancel;
			});

			return msgRet;
		}

		/// <summary>確認メッセージボックスを表示します。</summary>
		/// <param name="message">メッセージボックスに表示する内容を表す文字列。</param>
		/// <returns>メッセージボックスの選択結果を表すMessageBoxResult列挙型の内の1つ。</returns>
		public MessageBoxResult ShowConfirmMessage(string message)
		{
			return this.ShowConfirmMessage(message, "確認");
		}

		/// <summary>情報メッセージボックスを表示します。</summary>
		/// <param name="message">メッセージボックスに表示する内容を表す文字列。</param>
		/// <param name="title">メッセージボックスのタイトルを表す文字列。</param>
		public void ShowInformationMessage(string message, string title)
		{
			var notify = new Notification()
			{
				Content = message,
				Title = title
			};

			this.MessageBoxRequest.Raise(notify);
		}

		/// <summary>情報メッセージボックスを表示します。</summary>
		/// <param name="message">メッセージボックスに表示する内容を表す文字列。</param>
		public void ShowInformationMessage(string message)
		{
			this.ShowInformationMessage(message, "情報");
		}

		/// <summary>コンストラクタ。</summary>
		public MessageBoxService()
		{
			this.MessageBoxRequest = new InteractionRequest<INotification>();
		}
	}
}
