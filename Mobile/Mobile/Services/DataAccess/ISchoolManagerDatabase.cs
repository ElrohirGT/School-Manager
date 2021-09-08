using Mobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mobile.Services.DataAccess
{
    public interface ISchoolManagerDatabase
    {
        Task<UserModel> LogIn(string userName, string password);

        Task<int> GetTeacherId(UserModel user);

        Task<int> GetStudentId(UserModel user);

        Task<IEnumerable<T>> GetAllItemsFrom<T>() where T : new();

        Task<T> GetItemWithId<T>(int selectedId, bool recursive = true) where T : new();

        Task<IEnumerable<T>> GetAllItemsFrom<T>(System.Linq.Expressions.Expression<System.Func<T, bool>> filter, bool recursive = true) where T : new();
    }
}