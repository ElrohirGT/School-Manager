using System.Drawing;
using System.Windows.Forms;

namespace Controller.Renderers.Templates
{
    public partial class BasicCRUDPageTemplate : Form
    {
        public TableLayoutPanel InputsContainer => _inputsContainer;
        public DataGridView DataDisplay => _dataDisplay;
        public Button AddButton => _addButton;
        public Button EditButton => _editButton;
        public Button DeleteButton => _deleteButton;

        public BasicCRUDPageTemplate(string title, Color pageColor)
        {
            InitializeComponent();
            _titleLabel.Text = title;
            _titleLabel.BackColor = pageColor;
            _dataDisplay.AutoGenerateColumns = true;

            _addButton.ApplyTheme(pageColor);
            _editButton.ApplyTheme(pageColor);
            _deleteButton.ApplyTheme(pageColor);
        }
    }
}