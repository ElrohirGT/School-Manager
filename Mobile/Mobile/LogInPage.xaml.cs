using Mobile.ViewModels;
using Xamarin.Forms;

namespace Mobile
{
    public partial class LogInPage : ContentPage
    {
        private LogInPageViewModel _viewModel;

        public LogInPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new LogInPageViewModel(this);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.OnAppearing();
        }
    }
}