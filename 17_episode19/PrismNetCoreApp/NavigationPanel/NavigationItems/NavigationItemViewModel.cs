using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Prism.Mvvm;
using PrismNetCoreApp.ExamManagements;
using PrismNetCoreApp.PhysicalManagements;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace PrismNetCoreApp.NavigationItems
{
	public class NavigationItemViewModel : BindableBase
	{
		#region プロパティ

		public ReadOnlyReactivePropertySlim<string> Text { get; private set; }

		public ReadOnlyReactiveCollection<NavigationItemViewModel> Children { get; private set; }

		public ReactivePropertySlim<bool> IsExpanded { get; set; }

		public ReactivePropertySlim<bool> IsSelected { get; set; }

		public ReactivePropertySlim<NavigationCategory> ItemCategory { get; private set; }

		#endregion

		#region メソッド

		public void AddViewModel(NavigationItemViewModel vm)
		{
			if (this.sourceRecord is CategoryItem)
				return;

			this.viewModels.Add(vm);
		}

		#endregion

		#region コンストラクタ

		private PersonalRecord sourceRecord = null;

		private NavigationItemViewModel parent = null;

		private CompositeDisposable disposables = new CompositeDisposable();

		public NavigationItemViewModel(PersonalRecord record, NavigationItemViewModel parentViewModel)
			: base()
		{
			this.sourceRecord = record;
			this.parent = parentViewModel;

			this.initializeProperties();

			this.IsExpanded = new ReactivePropertySlim<bool>(true)
				.AddTo(this.disposables);
			this.IsSelected = new ReactivePropertySlim<bool>(false)
				.AddTo(this.disposables);
		}

		private ObservableCollection<NavigationItemViewModel> viewModels = null;

		private void initializeProperties()
		{
			var category = NavigationCategory.CategoryNone;

			switch (this.sourceRecord)
			{
				case PersonalInformation p:
					this.Text = p.Name
						.ToReadOnlyReactivePropertySlim()
						.AddTo(this.disposables);
					category = NavigationCategory.PersonalInformation;
					break;
				case ExamRecord e:
					this.Text = e.TestDate
						.Select(d => string.IsNullOrEmpty(d) ? "新しい試験日" : d)
						.ToReadOnlyReactivePropertySlim()
						.AddTo(this.disposables);
					category = NavigationCategory.ExamInformation;
					break;
				case PhysicalRecord ph:
					this.Text = ph.MeasurementDate
						.Select(v => v.HasValue ? v.Value.ToString("yyy年MM月dd日") : "新しい測定")
						.ToReadOnlyReactivePropertySlim()
						.AddTo(this.disposables);
					category = NavigationCategory.PhysicalInformation;
					break;
				case CategoryItem c:
					this.Text = c.ItemText
						.ToReadOnlyReactivePropertySlim()
						.AddTo(this.disposables);
					category = NavigationCategory.CategoryRoot;
					break;
			}

			if (!(this.sourceRecord is CategoryItem))
			{
				this.viewModels = new ObservableCollection<NavigationItemViewModel>();
				this.Children = this.viewModels
					.ToReadOnlyReactiveCollection(v => v)
					.AddTo(this.disposables);
			}

			if (category != NavigationCategory.CategoryNone)
				this.ItemCategory = new ReactivePropertySlim<NavigationCategory>(category)
					.AddTo(this.disposables);
		}

		public NavigationItemViewModel(CategoryItem category, NavigationItemViewModel parentViewModel, PersonalInformation personData)
			: this(category, parentViewModel)
		{
			switch (category.Category.Value)
			{
				case NavigationCategory.PhysicalInformation:
					this.Children = personData.Physicals
						.ToReadOnlyReactiveCollection(p => new NavigationItemViewModel(p, parentViewModel))
						.AddTo(this.disposables);
					break;
				case NavigationCategory.ExamInformation:
					this.Children = personData.ExsamResults
						.ToReadOnlyReactiveCollection(e => new NavigationItemViewModel(e, parentViewModel))
						.AddTo(this.disposables);
					break;
			}
		}

		#endregion
	}
}
