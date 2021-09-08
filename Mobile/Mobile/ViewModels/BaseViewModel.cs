using Mobile.Services.DataAccess;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Mobile.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private bool _isBusy;

        private bool _isLoading;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        protected ISchoolManagerDatabase DataBase { get; private set; }

        public virtual async Task OnAppearing()
        {
            DataBase = await SchoolManagerDatabase.Instance;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
                    => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<T>(ref T variable, T value, [CallerMemberName] string propertyName = "")
        {
            bool valueIsTheSame = EqualityComparer<T>.Default.Equals(variable, value);
            if (valueIsTheSame)
                return false;

            variable = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}