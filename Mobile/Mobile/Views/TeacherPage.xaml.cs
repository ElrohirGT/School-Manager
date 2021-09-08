using Mobile.Models;
using Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeacherPage : ContentPage
    {
        private ReportViewViewModel<CourseModel, AssignationModel> _viewModel;
        private int _selectedId;
        private int _teacherId;

        public TeacherPage(int teacherId)
        {
            InitializeComponent();
            _teacherId = teacherId;
            BindingContext = _viewModel = new ReportViewViewModel<CourseModel, AssignationModel>(
                (a) => a.IdCurso == _selectedId,
                (c) => c.IdProfesor == _teacherId);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.OnAppearing();
        }

        private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Picker picker = (Picker)sender;
            CourseModel selectedItem = (CourseModel)picker.SelectedItem;
            if (selectedItem == null)
                return;
            _selectedId = selectedItem.IdCurso;
            _viewModel.UpdateCollectionView.Execute(null);
        }
    }
}