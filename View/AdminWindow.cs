using Controller;
using Controller.Renderers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using View.Properties;

namespace School_Manager
{
    public partial class AdminWindow : Form
    {
        private List<Button> _buttons = new List<Button>();
        private MainWindowController _controller;

        public AdminWindow()
        {
            InitializeComponent();
            SetActivePageButton(_homeButton);

            _controller = new MainWindowController(ClientPanel, new IPageRenderer[]
            {
                new HomePageRenderer(Resources.dbBackground),
                new BasicCRUDPageRenderer("Roles", "Rol", "Rol", Color.OrangeRed),
                new BasicCRUDPageRenderer("Usuarios", "Usuario", "UsuarioFull", Color.ForestGreen),
                new BasicCRUDPageRenderer("Estudiantes", "Estudiante", "EstudianteFull", Color.MediumPurple),
                new BasicCRUDPageRenderer("Profesores", "Profesor", "ProfesorFull", Color.YellowGreen),
                new BasicCRUDPageRenderer("Grados", "Grado", "Grado", Color.CornflowerBlue),
                new BasicCRUDPageRenderer("Cursos", "Curso", "CursoFull", Color.MediumAquamarine),
                new AssignationPageRenderer(Color.Cornsilk),
                new GradesPageRenderer("Notas", Color.HotPink)
            });

            _buttons.AddRange(new Button[]
            {
                _homeButton,
                _rolesButton,
                _usersButton,
                _studentsButton,
                _teachersButton,
                _gradesButton,
                _coursesButton,
                _assignationsButton,
                _calificationsButton,
                _closeButton
            });
            foreach (var button in _buttons)
            {
                button.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(button.BackColor);
                button.FlatAppearance.MouseOverBackColor = ControlPaint.Light(button.BackColor);
                button.Click += (s, e) => SetActivePageButton((Button)s);
            }
        }

        private void _homeButton_Click(object sender, EventArgs e) => _controller.GoToPage(0);

        private void _rolesButton_Click(object sender, EventArgs e) => _controller.GoToPage(1);

        private void _usersButton_Click(object sender, EventArgs e) => _controller.GoToPage(2);

        private void _studentsButton_Click(object sender, EventArgs e) => _controller.GoToPage(3);

        private void _teachersButton_Click(object sender, EventArgs e) => _controller.GoToPage(4);

        private void _gradesButton_Click(object sender, EventArgs e) => _controller.GoToPage(5);

        private void _coursesButton_Click(object sender, EventArgs e) => _controller.GoToPage(6);

        private void _assignationsButton_Click(object sender, EventArgs e) => _controller.GoToPage(7);

        private void _calificationsButton_Click(object sender, EventArgs e) => _controller.GoToPage(8);

        private void button1_Click(object sender, EventArgs e) => Close();

        private void SetActivePageButton(Button activeButton)
        {
            SuspendLayout();

            foreach (var button in _buttons)
                button.BackColor = Color.Gold;
            activeButton.BackColor = ControlPaint.Light(Color.Gold);

            ResumeLayout();
        }
    }
}