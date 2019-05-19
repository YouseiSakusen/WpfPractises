using Microsoft.Win32;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCommonDialog.Confirmations
{
	public class FileSelectCommonDialogConfirmationBase : Confirmation
	{
		/// <summary>ユーザーが拡張子を省略した場合に、ファイル ダイアログで自動的に
		/// ファイル名に拡張子を付けるかどうかを示す値を取得または設定します。</summary>
		public bool AddExtension { get; set; } = true;

		/// <summary>存在しないファイル名をユーザーが指定した場合に、
		/// ファイル ダイアログで警告を表示するかどうかを示す値を取得または設定します。</summary>
		public bool CheckFileExists { get; set; } = true;

		/// <summary>ユーザーが無効なパスとファイル名を入力した場合に
		/// 警告を表示するかどうかを指定する値を取得または設定します。</summary>
		public bool CheckPathExists { get; set; } = true;

		/// <summary>ファイル ダイアログ ボックスのカスタム プレースのリストを取得または設定します。</summary>
		public List<FileDialogCustomPlace> CustomPlaces { get; set; } = new List<FileDialogCustomPlace>();

		/// <summary>既定の拡張子文字列を指定する値を取得または設定します。</summary>
		public string DefaultExt { get; set; } = string.Empty;

		/// <summary>ファイル ダイアログが、ショートカットで参照されたファイルの場所を返すか、
		/// ショートカット ファイル (.lnk) の場所を返すかを示す値を取得または設定します。</summary>
		public bool DereferenceLinks { get; set; } = true;

		/// <summary>ファイル ダイアログで選択されたファイルの
		/// 完全なパスを含む文字列を取得または設定します。</summary>
		public string FileName { get; set; } = string.Empty;

		/// <summary>選択されたファイルごとに 1 つずつファイル名を格納する配列を取得します。</summary>
		public string[] FileNames { get; set; }

		/// <summary>ファイルの種類を決定するフィルター文字列を取得または設定します。</summary>
		public string Filter { get; set; } = string.Empty;

		/// <summary>ファイル ダイアログで現在選択されているフィルターのインデックスを取得または設定します。</summary>
		public int FilterIndex { get; set; } = 0;

		/// <summary>ファイル ダイアログに表示される初期ディレクトリを取得または設定します。</summary>
		public string InitialDirectory { get; set; } = string.Empty;

		/// <summary>選択されたファイルのファイル名のみを格納する文字列を取得します。</summary>
		public string SafeFileName { get; set; } = string.Empty;

		/// <summary>選択されたファイルごとに 1 つずつ安全なファイル名を格納する配列を取得します。</summary>
		public string[] SafeFileNames { get; set; }

		/// <summary>取得または設定ダイアログに関連付けられているオブジェクト。 
		/// これは、ダイアログ ボックスに、任意のオブジェクトをアタッチできる機能を提供します。</summary>
		public object Tag { get; set; } = null;

		/// <summary>ダイアログが有効な Win32 ファイル名だけを受け入れるかどうかを示す値を取得または設定します。</summary>
		public bool ValidateName { get; set; } = true;
	}
}
