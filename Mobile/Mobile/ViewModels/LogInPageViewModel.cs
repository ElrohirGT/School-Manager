using Mobile.Models;
using Mobile.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class LogInPageViewModel : BaseViewModel
    {
        private string _error;
        private bool _hasError;
        private LogInPage _page;
        private string _password;
        private string _userName;

        public LogInPageViewModel(LogInPage page)
        {
            _page = page;
            LogInCommand = new Command(async () =>
            {
                IsBusy = true;
                HasError = false;
                UserModel user = await DataBase.LogIn(UserName, Password);
                if (user is null)
                    user = new UserModel() { IdRol = -1 };
                switch ((Roles)user.IdRol)
                {
                    case Roles.Administrador:
                        await GotToPage(new AdminPage());
                        break;

                    case Roles.Profesor:
                        int teacherId = await DataBase.GetTeacherId(user);
                        await GotToPage(new TeacherPage(teacherId));
                        break;

                    case Roles.Estudiante:
                        int studentId = await DataBase.GetStudentId(user);
                        await GotToPage(new StudentPage(studentId));
                        break;

                    default:
                        HasError = true;
                        Error = "Usuario o contraseña incorrecta!";
                        break;
                }
                ResetFields();
                IsBusy = false;
            });
        }

        private Task GotToPage(Page page) => _page.Navigation.PushAsync(page);

        private void ResetFields()
        {
            UserName = string.Empty;
            Password = string.Empty;
        }

        public string Error
        {
            get => _error;
            set => SetProperty(ref _error, value);
        }

        public bool HasError
        {
            get => _hasError;
            set => SetProperty(ref _hasError, value);
        }

        public ICommand LogInCommand { get; }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
    }
}