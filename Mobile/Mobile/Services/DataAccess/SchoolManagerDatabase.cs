using Mobile.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.Services.DataAccess
{
    public class SchoolManagerDatabase : ISchoolManagerDatabase
    {
        private static SQLiteAsyncConnection _dbConn;

        public static readonly AsyncLazy<ISchoolManagerDatabase> Instance = new AsyncLazy<ISchoolManagerDatabase>(async () =>
        {
            var instance = new SchoolManagerDatabase();
            await _dbConn.CreateTableAsync<RoleModel>();
            await _dbConn.CreateTableAsync<UserModel>();
            await _dbConn.CreateTableAsync<StudentModel>();
            await _dbConn.CreateTableAsync<TeacherModel>();
            await _dbConn.CreateTableAsync<GradeModel>();
            await _dbConn.CreateTableAsync<CourseModel>();
            await _dbConn.CreateTableAsync<AssignationModel>();

            return instance;
        });

        public SchoolManagerDatabase()
        {
            try
            {
                //_dbConn = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadOnly);
                _dbConn = DependencyService.Get<IDBConnectionCreator>().Create();
            }
            catch (Exception e)
            {
                if (e.Message.StartsWith("1")) { }
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllItemsFrom<T>() where T : new()
            => await _dbConn.GetAllWithChildrenAsync<T>();

        public async Task<IEnumerable<T>> GetAllItemsFrom<T>(Expression<Func<T, bool>> filter, bool recursive = false) where T : new()
        {
            //var list = await _dbConn.Table<T>().Where(filter).ToArrayAsync();
            //var taskList = new List<Task>();

            //foreach (var element in list)
            //    taskList.Add(_dbConn.GetChildrenAsync(element, recursive = false));
            //await Task.WhenAll(taskList);

            //return list;
            return await _dbConn.GetAllWithChildrenAsync(filter, recursive);
        }

        public Task<T> GetItemWithId<T>(int selectedId, bool recursive = true) where T : new()
            => _dbConn.GetWithChildrenAsync<T>(selectedId);

        public async Task<int> GetStudentId(UserModel user)
            => (await _dbConn.FindWithQueryAsync<StudentModel>($"SELECT IdEstudiante FROM Estudiante WHERE IdUsuario={user.IdUsuario}")).IdEstudiante;

        public async Task<int> GetTeacherId(UserModel user)
            => (await _dbConn.FindWithQueryAsync<TeacherModel>($"SELECT IdProfesor FROM Profesor WHERE IdUsuario={user.IdUsuario}")).IdProfesor;

        public Task<UserModel> LogIn(string userName, string password)
        {
            string query = $"SELECT * FROM Usuario WHERE Nombre='{userName}' AND Contraseña='{password}'";
            return _dbConn.FindWithQueryAsync<UserModel>(query);
        }
    }
}