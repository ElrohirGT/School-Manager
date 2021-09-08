using System.Data;
using System.Windows.Forms;

namespace Controller.Renderers.Templates
{
    public partial class StudentGradesPageTemplate : Form
    {
        public StudentGradesPageTemplate(DataTable source)
        {
            InitializeComponent();
            _dataDisplay.AutoGenerateColumns = true;
            _dataDisplay.DataSource = source;
        }
    }
}