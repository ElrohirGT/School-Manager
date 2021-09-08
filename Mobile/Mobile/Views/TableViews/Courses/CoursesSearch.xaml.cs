using Mobile.Models;
using Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.TableViews.Courses
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursesSearch : ContentPage
    {
        private SearchViewViewModel<CourseModel> _viewModel;

        public CoursesSearch()
        {
            InitializeComponent();
            BindingContext = _viewModel = new SearchViewViewModel<CourseModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.OnAppearing();
        }
    }
}