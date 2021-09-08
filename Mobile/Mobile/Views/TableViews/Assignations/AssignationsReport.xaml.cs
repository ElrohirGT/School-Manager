using Mobile.Models;
using Mobile.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views.TableViews.Assignations
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssignationsReport : ContentPage
    {
        private ReportViewViewModel<CourseModel, AssignationModel> _viewModel;
        private int _selectedId;

        public AssignationsReport()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ReportViewViewModel<CourseModel, AssignationModel>((a) => a.IdCurso == _selectedId);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.OnAppearing();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
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