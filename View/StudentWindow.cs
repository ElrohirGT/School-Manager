using Controller;
using Controller.Renderers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using View.Properties;

namespace School_Manager
{
    public partial class StudentWindow : Form
    {
        private List<Button> _buttons = new List<Button>();
        private MainWindowController _controller;

        public StudentWindow(int idEstudiante)
        {
            InitializeComponent();
            SetActivePageButton(_homeButton);

            _controller = new MainWindowController(ClientPanel, new IPageRenderer[]
            {
                new HomePageRenderer(Resources.dbBackground),
                new StudentsPageRenderer(idEstudiante),
            });

            _buttons.AddRange(new Button[]
            {
                _homeButton,
                _calificationsButton,
                _closeButton
            });
            foreach (var button in _buttons)
            {
                //button.BackColor = Color.Gold;
                button.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(button.BackColor);
                button.FlatAppearance.MouseOverBackColor = ControlPaint.Light(button.BackColor);
                button.Click += (s, e) => SetActivePageButton((Button)s);
            }
        }

        private void _homeButton_Click(object sender, EventArgs e) => _controller.GoToPage(0);

        private void _calificationsButton_Click(object sender, EventArgs e) => _controller.GoToPage(1);

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