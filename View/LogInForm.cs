using Controller;
using System;
using System.Windows.Forms;

namespace School_Manager
{
    public partial class LogInForm : Form
    {
        private LogInWindowController _controller;

        public LogInForm()
        {
            InitializeComponent();
            _controller = new LogInWindowController(_userNameTextBox, _passwordTextBox);
        }

        private void _submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                Roles role = (Roles)_controller.TryLogIn();
                int id;
                switch (role)
                {
                    case Roles.Administrador:
                        InitializeForm(new AdminWindow());
                        break;

                    case Roles.Maestro:
                        id = _controller.GetTeacherId();
                        InitializeForm(new TeacherWindow(id));
                        break;

                    case Roles.Estudiante:
                        id = _controller.GetStudentId();
                        InitializeForm(new StudentWindow(id));
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(this, "Usuario o contraseña incorrecta!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeForm(Form form)
        {
            form.FormClosed += RegisterForm_FormClosed;
            Hide();
            _userNameTextBox.Text = string.Empty;
            _passwordTextBox.Text = string.Empty;
            form.Show();
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e) => Show();
    }
}