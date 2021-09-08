using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class SearchViewViewModel<T> : BaseViewModel where T : new()
    {
        private bool _hasStudent = false;
        private string _selectedId;
        private T _selectedItem;

        public SearchViewViewModel()
        {
            SearchItemCommand = new Command(async () =>
            {
                IsBusy = true;
                string id = string.IsNullOrEmpty(SelectedId) ? "0" : SelectedId;
                HasItem = false;
                try
                {
                    SelectedItem = await DataBase.GetItemWithId<T>(int.Parse(id), true);
                    HasItem = true;
                }
                catch (System.Exception e) { }

                IsBusy = false;
            });
        }

        public bool HasItem
        {
            get => _hasStudent;
            set => SetProperty(ref _hasStudent, value);
        }

        public ICommand SearchItemCommand { get; }

        public string SelectedId
        {
            get => _selectedId;
            set => SetProperty(ref _selectedId, value);
        }

        public T SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }
    }
}