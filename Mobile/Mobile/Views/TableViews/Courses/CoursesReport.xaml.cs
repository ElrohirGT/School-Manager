using Mobile.Models;
using Mobile.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.TableViews.Courses
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursesReport : ContentPage
    {
        private ReportViewViewModel<GradeModel, CourseModel> _viewModel;
        private int _selectedId;

        public CoursesReport()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ReportViewViewModel<GradeModel, CourseModel>((c) => c.IdGrado == _selectedId);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.OnAppearing();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            GradeModel selectedItem = (GradeModel)picker.SelectedItem;
            if (selectedItem == null)
                return;
            _selectedId = selectedItem.IdGrado;
            _viewModel.UpdateCollectionView.Execute(null);
        }
    }
}