using Mobile.Models;
using Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.TableViews.Courses
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursesView : ContentPage
    {
        private TableViewViewModel<CourseModel> _viewModel;

        public CoursesView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TableViewViewModel<CourseModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.OnAppearing();
        }
    }
}