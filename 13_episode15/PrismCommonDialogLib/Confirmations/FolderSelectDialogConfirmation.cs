using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCommonDialog.Confirmations
{
	public class FolderSelectDialogConfirmation : FileSelectCommonDialogConfirmationBase
	{
		/// <summary>ダイアログの説明文を取得・設定します。</summary>
		public string Description { get; set; } = string.Empty;

		/// <summary>ルートフォルダを取得・設定します。</summary>
		public System.Environment.SpecialFolder RootFolder { get; set; } = Environment.SpecialFolder.Desktop;

		/// <summary>選択したフォルダのパスを取得・設定します。</summary>
		public string SelectedPath { get; set; } = string.Empty;

		/// <summary>新しいフォルダの作成ボタンを表示するかを取得・設定します。</summary>
		public bool ShowNewFolderButton { get; set; } = true;

		/// <summary>Descriptionに指定した文字列をタイトルに設定するかを取得・設定します。</summary>
		public bool UseDescriptionForTitle { get; set; } = false;
	}
}
