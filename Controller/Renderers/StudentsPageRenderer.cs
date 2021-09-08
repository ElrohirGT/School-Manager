using Controller.Renderers.Templates;
using Model;
using System.Data;
using System.Windows.Forms;

namespace Controller.Renderers
{
    public class StudentsPageRenderer : BasePageRenderer
    {
        private DataTable _source = new DataTable();
        private int _idEstudiante;
        private StudentGradesPageTemplate _template;

        public StudentsPageRenderer(int idEstudiante) => _idEstudiante = idEstudiante;

        public override void PopulatePage(DBConnection conn)
        {
            _source.Clear();
            string query =
                "SELECT Grado, Curso, [Nota IU], [Nota IIU], [Nota IIIU], [Nota IVU] " +
                $"FROM AsignacionFull WHERE IdEstudiante = {_idEstudiante}";
            using (var reader = conn.Query(query))
            {
                _source.Load(reader);
            }
        }

        public override void RenderPage(Panel panel, DBConnection conn)
        {
            _template = new StudentGradesPageTemplate(_source);
            _template.TopLevel = false;
            _template.Dock = DockStyle.Fill;
            _template.Visible = true;
            _template.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(_template);
        }
    }
}