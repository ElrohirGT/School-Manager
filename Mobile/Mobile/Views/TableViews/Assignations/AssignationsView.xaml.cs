using Mobile.Models;
using Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.TableViews.Assignations
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssignationsView : ContentPage
    {
        private TableViewViewModel<AssignationModel> _viewModel;

        public AssignationsView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TableViewViewModel<AssignationModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.OnAppearing();
        }
    }
}