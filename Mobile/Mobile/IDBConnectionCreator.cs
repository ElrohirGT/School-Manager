using SQLite;

namespace Mobile
{
    public interface IDBConnectionCreator
    {
        SQLiteAsyncConnection Create();
    }
}