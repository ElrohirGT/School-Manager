using Mobile.Models;
using Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.TableViews.Assignations
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssignationsSearch : ContentPage
    {
        private SearchViewViewModel<AssignationModel> _viewModel;

        public AssignationsSearch()
        {
            InitializeComponent();
            BindingContext = _viewModel = new SearchViewViewModel<AssignationModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.OnAppearing();
        }
    }
}