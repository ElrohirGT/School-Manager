using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class ReportViewViewModel<PickerType, CollectionType> : BaseViewModel
        where PickerType : class, new()
        where CollectionType : class, new()
    {
        public string _foreignIdName;
        public string _primaryIdName;
        private Expression<Func<CollectionType, bool>> _getIdOfCollectionType;
        private Expression<Func<PickerType, bool>> _getIdOfPickerType;

        public ReportViewViewModel(Expression<Func<CollectionType, bool>> getIdOfCollectionType) : this(getIdOfCollectionType, null)
        {
        }

        public ReportViewViewModel(Expression<Func<CollectionType, bool>> getIdOfCollectionType, Expression<Func<PickerType, bool>> getIdOfPickerType)
        {
            _getIdOfCollectionType = getIdOfCollectionType;
            _getIdOfPickerType = getIdOfPickerType;
            UpdateCollectionView = new Command(async () =>
            {
                IsBusy = true;
                CollectionItems.Clear();
                try
                {
                    IEnumerable<CollectionType> collectionItems = await DataBase.GetAllItemsFrom(_getIdOfCollectionType, true);
                    if (collectionItems != null)
                        foreach (CollectionType collectionItem in collectionItems)
                            CollectionItems.Add(collectionItem);
                }
                catch (Exception e)
                {
                    throw;
                }
                IsBusy = false;
            });
        }

        public ICommand UpdateCollectionView { get; }

        public ObservableCollection<PickerType> PickerItems { get; } = new ObservableCollection<PickerType>();

        public ObservableCollection<CollectionType> CollectionItems { get; } = new ObservableCollection<CollectionType>();

        public override async Task OnAppearing()
        {
            IsLoading = true;
            await base.OnAppearing();
            CollectionItems.Clear();
            PickerItems.Clear();

            IEnumerable<PickerType> courses;
            if (_getIdOfPickerType != null)
                courses = await DataBase.GetAllItemsFrom(_getIdOfPickerType);
            else
                courses = await DataBase.GetAllItemsFrom<PickerType>();
            foreach (var course in courses)
                PickerItems.Add(course);
            IsLoading = false;
        }
    }
}