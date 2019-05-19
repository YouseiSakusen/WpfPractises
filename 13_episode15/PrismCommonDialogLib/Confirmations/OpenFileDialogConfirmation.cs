using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCommonDialog.Confirmations
{
	public class OpenFileDialogConfirmation : FileSelectCommonDialogConfirmationBase
	{
		/// <summary>複数のファイルを選択できるかどうかを取得または設定します。</summary>
		public bool Multiselect { get; set; } = false;

		/// <summary>読み取り専用チェック ボックスがチェックされているかどうかを取得または設定します。</summary>
		public bool ReadOnlyChecked { get; set; } = false;

		/// <summary>読み取り専用チェック ボックスを表示するかを取得・設定します。</summary>
		public bool ShowReadOnly { get; set; } = false;
	}
}
