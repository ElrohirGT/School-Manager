using System.Drawing;
using System.Windows.Forms;

namespace Controller.Renderers.Templates
{
    public partial class GradesPageTemplate : Form
    {
        public TableLayoutPanel InputsContainer => _inputsContainer;
        public DataGridView DataDisplay => _dataDisplay;

        public GradesPageTemplate(string title, Color pageColor)
        {
            InitializeComponent();
            _titleLabel.Text = title;
            _titleLabel.BackColor = pageColor;
            _dataDisplay.AutoGenerateColumns = true;
        }
    }
}