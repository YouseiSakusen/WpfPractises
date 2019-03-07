using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace WpfTestApp.ViewModels
{
	/// <summary> 身体測定データの編集画面を表します。 </summary>
	public class PhysicalEditorViewModel : BindableBase, IDisposable, IConfirmNavigationRequest
	{
		#region "バインディング"

		/// <summary>測定日を取得・設定します。</summary>
		public ReactiveProperty<DateTime?> MeasurementDate { get; set; }

		/// <summary>身長を取得・設定します。</summary>
		[RegularExpression(@"^\d{1,3}(\.\d{1,2})?$",
			ErrorMessage = "身長は整数3桁 少数2桁の範囲で入力してください。")]
		public ReactiveProperty<double> Height { get; set; }

		/// <summary>体重を取得・設定します。</summary>
		[RegularExpression(@"^\d{1,3}(\.\d{1,2})?$",
			ErrorMessage = "体重は整数3桁 少数2桁の範囲で入力してください。")]
		public ReactiveProperty<double> Weight { get; set; }

		/// <summary>BMIを取得します。</summary>
		public ReadOnlyReactivePropertySlim<double> Bmi { get; private set; }

		///// <summary>情報MessageBoxを表示します。</summary>
		//public InteractionRequest<INotification> MessageBoxRequest { get; private set; }

		#endregion

		///// <summary>確認メッセージボックスを表示します。</summary>
		///// <param name="message">メッセージボックスに表示する内容を表す文字列。</param>
		///// <param name="title">メッセージボックスのタイトルを表す文字列。</param>
		///// <returns>メッセージボックスの選択結果を表すMessageBoxResult列挙型の内の1つ。</returns>
		//private MessageBoxResult showConfirmMessage(string message, string title = "問い合わせ")
		//{
		//	var confirm = new Confirmation()
		//	{
		//		Content = message,
		//		Title = title
		//	};

		//	var msgRet = MessageBoxResult.Cancel;
		//	this.MessageBoxRequest.Raise(confirm, r =>
		//	{
		//		msgRet = (r as IConfirmation).Confirmed ? MessageBoxResult.OK : MessageBoxResult.Cancel;
		//	});

		//	return msgRet;
		//}

		///// <summary>情報メッセージボックスを表示します。</summary>
		///// <param name="message">メッセージボックスに表示する内容を表す文字列。</param>
		///// <param name="title">メッセージボックスのタイトルを表す文字列。</param>
		//private void showInformationMessage(string message, string title = "情報")
		//{
		//	var notify = new Notification()
		//	{
		//		Content = message,
		//		Title = title
		//	};

		//	this.MessageBoxRequest.Raise(notify);
		//}

		/// <summary>他 View への遷移を確認します。</summary>
		/// <param name="navigationContext">遷移先の情報を表すNavigationContext。</param>
		/// <param name="continuationCallback">遷移を続行するかを判定するコールバック。</param>
		public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
		{
			this.MeasurementDate.ForceValidate();
			this.Height.ForceValidate();
			this.Weight.ForceValidate();

			//var isMove = !(this.MeasurementDate.HasErrors | this.Height.HasErrors | this.Weight.HasErrors);
			//continuationCallback(isMove);

			//if (!isMove)
			//	this.messageBoxService.ShowInformationMessage("エラーが存在するため、別画面を表示できません。");

			var isMove = true;

			if (this.MeasurementDate.HasErrors | this.Height.HasErrors | this.Weight.HasErrors)
			{
				if (this.messageBoxService.ShowConfirmMessage("別画面に遷移しますか？") == MessageBoxResult.Cancel)
					isMove = false;
			}

			continuationCallback(isMove);
		}

		/// <summary>身体測定データを取得します。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		/// <returns>NavigationContextから取得したPhysicalInformation。</returns>
		private PhysicalInformation getPhysicalData(NavigationContext navigationContext)
		{
			return navigationContext.Parameters["TargetData"] as PhysicalInformation;
		}

		/// <summary>表示するViewを判別します。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		/// <returns>表示するViewかどうかを表すbool。</returns>
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			var physicalDat = this.getPhysicalData(navigationContext);

			return this.physical.Id == physicalDat.Id;
		}

		/// <summary>別のViewに切り替わる前に呼び出されます。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		public void OnNavigatedFrom(NavigationContext navigationContext) { return; }

		/// <summary>測定日のエラー文字列を取得します。</summary>
		/// <param name="value">View で入力されたDateTime?。</param>
		/// <returns>測定日のエラー文字列</returns>
		private string getMeasurementDateError(DateTime? value)
		{
			if (!value.HasValue)
				return "必須入力です。";

			if (this.appData.HasPhysicalKey(value, this.physical))
			{
				this.MeasurementDate.Value = this.physical.MeasurementDate;
				return "既に同一の測定日が存在するため、別の日付を設定してください。";
			}
			else
				return null;
		}

		private PhysicalInformation physical = null;
		private System.Reactive.Disposables.CompositeDisposable disposables =
			new System.Reactive.Disposables.CompositeDisposable();

		/// <summary>Viewを表示した後呼び出されます。</summary>
		/// <param name="navigationContext">Navigation Requestの情報を表すNavigationContext。</param>
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			if (this.physical != null)
				return;
			this.physical = this.getPhysicalData(navigationContext);

			var mode = ReactivePropertyMode.Default | ReactivePropertyMode.IgnoreInitialValidationError;

			// 測定日
			this.MeasurementDate = this.physical
				.ToReactivePropertyAsSynchronized(x => x.MeasurementDate, mode, true)
				.SetValidateNotifyError(v => this.getMeasurementDateError(v))
				.AddTo(this.disposables);
			// 身長
			this.Height = this.physical
				.ToReactivePropertyAsSynchronized(x => x.Height, ignoreValidationErrorValue: true)
				.SetValidateAttribute(() => this.Height)
				.AddTo(this.disposables);
			// 体重
			this.Weight = this.physical
				.ToReactivePropertyAsSynchronized(x => x.Weight, ignoreValidationErrorValue: true)
				.SetValidateAttribute(() => this.Weight)
				.AddTo(this.disposables);
			// BMI
			this.Bmi = this.physical.ObserveProperty(x => x.Bmi)
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			// View へ反映
			this.RaisePropertyChanged(null);
		}

		/// <summary>アプリデータ本体を表します。</summary>
		private WpfTestAppData appData = null;
		/// <summary>メッセージボックス表示Service。</summary>
		private MessageBoxService messageBoxService = null;

		/// <summary>コンストラクタ。</summary>
		/// <param name="data">アプリのデータオブジェクト（Unity からインジェクション）</param>
		public PhysicalEditorViewModel(WpfTestAppData data, MessageBoxService msgService)
		{
			this.appData = data;
			this.messageBoxService = msgService;
		}

		/// <summary>オブジェクトを破棄します。</summary>
		void IDisposable.Dispose() { this.disposables.Dispose(); }
	}
}
