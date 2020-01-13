using System;
using Prism.Commands;
using Prism.Mvvm;

namespace MvvmSample.ViewModels
{
	/// <summary>Personクラス。</summary>
	public class Person
	{
		/// <summary>名前を取得・設定します。</summary>
		public string Name { get; set; } = string.Empty;
		/// <summary>誕生日を取得・設定します。</summary>
		public DateTime? Birthday { get; set; } = null;
	}

	/// <summary>ユーザの読込と保存を行う。</summary>
	public static class UserAgent
	{
		/// <summary>ユーザデータを読み込む。</summary>
		/// <returns>読み込んだユーザを表すPerson。</returns>
		public static Person Load() //{ return new Person(); }
		{
			return new Person()
			{
				Birthday = DateTime.Parse("1980/1/1"),
				Name = "沖田玲郎"
			};
		}

		/// <summary>ユーザデータを保存する。</summary>
		/// <param name="target">保存するユーザを表すPerson。</param>
		public static void Save(Person target) { return; }
	}

	/// <summary>Prism Shell の VM。</summary>
	public class MainWindowViewModel : BindableBase
	{
		private string userName = string.Empty;
		/// <summary>ユーザ名を取得・設定します。</summary>
		public string UserName
		{
			get { return userName; }
			set { SetProperty(ref userName, value); }
		}

		private DateTime? userbirth = null;
		/// <summary>ユーザの誕生日を取得・設定します。</summary>
		public DateTime? UserBirthDay
		{
			get { return userbirth; }
			set
			{
				SetProperty(ref userbirth, value);

				if (userbirth.HasValue)
				{
					var today = DateTime.Now.Date;
					var year = today.Year - this.userbirth.Value.Year;
					if (today.AddDays(-year) < this.userbirth)
						year--;

					this.UserAge = year;
				}
			}
		}

		private int age;
		/// <summary>ユーザの年齢を取得します。</summary>
		public int UserAge
		{
			get { return age; }
			private set { SetProperty(ref age, value); }
		}

		private DelegateCommand saveCmd;
		/// <summary>ユーザの保存コマンド。</summary>
		public DelegateCommand SaveCommand =>
			saveCmd ?? (saveCmd = new DelegateCommand(ExecuteSaveCommand, CanExecuteSaveCommand));

		/// <summary>ユーザの保存を実行します。</summary>
		void ExecuteSaveCommand()
		{
			var user = new Person()
			{
				Birthday = this.UserBirthDay,
				Name = this.UserName
			};

			UserAgent.Save(user);
		}

		/// <summary>ユーザの保存ボタンの実行可否を取得・設定します。</summary>
		/// <returns>ユーザの保存ボタンの実行可否を表すbool。</returns>
		bool CanExecuteSaveCommand()
		{
			return true;
		}

		/// <summary>コンストラクタ。</summary>
		public MainWindowViewModel()
		{
			var user = UserAgent.Load();

			this.userName = user.Name;
			this.UserBirthDay = user.Birthday;
		}
	}
}
