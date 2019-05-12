using Microsoft.Win32;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Interactivity;

namespace PrismCommonDialog
{
	public class PopupCommonDialogAction : TriggerAction<FrameworkElement>
	{
		/// <summary>ダイアログの種類を取得・設定します。</summary>
		public static readonly DependencyProperty CommonDialogTypeProperty =
			DependencyProperty.Register(nameof(PopupCommonDialogAction.CommonDialogType),
										typeof(Type),
										typeof(PopupCommonDialogAction),
										new PropertyMetadata(null));

		/// <summary>ダイアログの種類を取得・設定します。</summary>
		public Type CommonDialogType
		{
			get { return (Type)this.GetValue(PopupCommonDialogAction.CommonDialogTypeProperty); }
			set { this.SetValue(PopupCommonDialogAction.CommonDialogTypeProperty, value); }
		}

		/// <summary>CommonDialogをポップアップします。</summary>
		/// <param name="parameter">アクションを呼び出す対象のobject。</param>
		protected override void Invoke(object parameter)
		{
			// ① InteractionRequestに設定されているパラメータを取得
			var args = parameter as InteractionRequestedEventArgs;
			if (args == null)
				return;
			if (this.CommonDialogType == null)
				throw new ArgumentException("FileDialogTypeプロパティが設定されていません");

			// ② CommonDialogTypeプロパティに設定されているTypeのインスタンスを生成
			var dialog = (CommonDialog)Activator.CreateInstance(this.CommonDialogType);

			// ③ パラメータに定義されているプロパティの値をコモンダイアログの同名のプロパティへコピー
			foreach (var prop in args.Context.GetType().GetProperties())
			{
				var value = prop.GetValue(args.Context, null);
				if (value == null)
					continue;

				var dialogProp = dialog.GetType().GetProperties()
					.FirstOrDefault(p => p.Name.Equals(prop.Name, StringComparison.CurrentCultureIgnoreCase));
				if ((dialogProp != null) && (dialogProp.CanWrite))
				{
					dialogProp.SetValue(dialog, value, null);
				}
			}

			// ④ コモンダイアログを表示
			var ret = dialog.ShowDialog();

			// ⑤ コモンダイアログのプロパティからパラメータの同名プロパティへ値を戻すためのコピー
			foreach (var prop in dialog.GetType().GetProperties())
			{
				var contextProp = args.Context.GetType().GetProperties()
					.FirstOrDefault(p => p.Name.Equals(prop.Name, StringComparison.CurrentCultureIgnoreCase));
				if ((contextProp != null) && (contextProp.CanWrite))
				{
					contextProp.SetValue(args.Context, prop.GetValue(dialog, null), null);
				}
			}

			// ⑥ パラメータはIConfirmationが前提なので戻り値をセット
			var confirm = args.Context as IConfirmation;
			if ((confirm != null) && (ret.HasValue))
			{
				confirm.Confirmed = ret.Value == true;
			}

			args.Callback();
		}
	}
}
