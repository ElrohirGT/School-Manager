using Model;
using System.Windows.Forms;

namespace Controller
{
    public class LogInWindowController
    {
        private TextBox _usernameTextBox;
        private TextBox _passwordTextBox;

        public LogInWindowController(TextBox usernameTextBox, TextBox passwordTextBox)
        {
            _usernameTextBox = usernameTextBox;
            _passwordTextBox = passwordTextBox;
        }

        private string UserName => _usernameTextBox.Text;
        private string Password => _passwordTextBox.Text;

        public int TryLogIn()
        {
            using (DBConnection conn = new DBConnection())
            {
                return conn.LogIn(UserName, Password);
            }
        }

        public int GetStudentId()
        {
            using (DBConnection conn = new DBConnection())
            {
                return conn.GetStudentId(UserName);
            }
        }

        public int GetTeacherId()
        {
            using (DBConnection conn = new DBConnection())
            {
                return conn.GetTeacherId(UserName);
            }
        }
    }
}