using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mobile.ViewModels
{
    public class TableViewViewModel<T> : BaseViewModel where T : new()
    {
        private Expression<Func<T, bool>> _filter;

        public TableViewViewModel() : this(null)
        {
        }

        public TableViewViewModel(Expression<Func<T, bool>> filter) => _filter = filter;

        public ObservableCollection<T> Items { get; } = new ObservableCollection<T>();

        public override async Task OnAppearing()
        {
            IsLoading = true;
            Items.Clear();
            await base.OnAppearing();

            IEnumerable<T> items;
            if (_filter != null)
                items = await DataBase.GetAllItemsFrom(_filter, true);
            else
                items = await DataBase.GetAllItemsFrom<T>();
            foreach (T item in items)
                Items.Add(item);

            IsLoading = false;
        }
    }
}