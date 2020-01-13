using System.Windows;
using Prism.Interactivity.InteractionRequest;

namespace WpfTestApp
{
	public interface IMessageBoxService
	{
		/// <summary>MessageBoxを表示します。</summary>
		InteractionRequest<INotification> MessageBoxRequest { get; }

		/// <summary>確認メッセージボックスを表示します。</summary>
		/// <param name="message">メッセージボックスに表示する内容を表す文字列。</param>
		/// <param name="title">メッセージボックスのタイトルを表す文字列。</param>
		/// <returns>メッセージボックスの選択結果を表すMessageBoxResult列挙型の内の1つ。</returns>
		MessageBoxResult ShowConfirmMessage(string message, string title);

		/// <summary>確認メッセージボックスを表示します。</summary>
		/// <param name="message">メッセージボックスに表示する内容を表す文字列。</param>
		/// <returns>メッセージボックスの選択結果を表すMessageBoxResult列挙型の内の1つ。</returns>
		MessageBoxResult ShowConfirmMessage(string message);

		/// <summary>情報メッセージボックスを表示します。</summary>
		/// <param name="message">メッセージボックスに表示する内容を表す文字列。</param>
		/// <param name="title">メッセージボックスのタイトルを表す文字列。</param>
		void ShowInformationMessage(string message, string title);

		/// <summary>情報メッセージボックスを表示します。</summary>
		/// <param name="message">メッセージボックスに表示する内容を表す文字列。</param>
		void ShowInformationMessage(string message);
	}
}
