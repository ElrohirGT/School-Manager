using Mobile.Models;
using Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentPage : ContentPage
    {
        private TableViewViewModel<AssignationModel> _viewModel;
        private int _studentId;

        public StudentPage(int studentId)
        {
            InitializeComponent();
            _studentId = studentId;
            BindingContext = _viewModel = new TableViewViewModel<AssignationModel>((a) => a.IdEstudiante == _studentId);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.OnAppearing();
        }
    }
}