using Controller.Renderers.Templates;
using Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Controller.Renderers
{
    public class AssignationPageRenderer : BasePageRenderer
    {
        private readonly string[] FIELDS = new string[2] { "IdCurso", "IdEstudiante" };
        private Button _activeButton;
        private DBConnection _conn;
        private Color _pageColor;
        private string _pageTitle = "Asignaciones";
        private int _selectedPrimaryId;
        private ManyToManyCRUDTemplate _template;

        public AssignationPageRenderer(Color pageColor) => _pageColor = pageColor;

        public override void PopulatePage(DBConnection conn) => SetUpSideBoard(_template.InputsContainer, conn);

        public override void RenderPage(Panel panel, DBConnection conn)
        {
            _conn = conn;
            _template = new ManyToManyCRUDTemplate(
                _pageTitle, _pageColor,
                (secondaryItemId) =>
                {
                    SqlParameter[] sqlParameters = new SqlParameter[]
                    {
                        new SqlParameter("@param0", _selectedPrimaryId),
                        new SqlParameter("@param1", secondaryItemId)
                    };
                    conn.Insert("Asignacion", FIELDS, sqlParameters);
                },
                (secondayItemId) =>
                {
                    conn.Delete("Asignacion", FIELDS, new object[] { _selectedPrimaryId, secondayItemId });
                }
            );
            _template.TopLevel = false;
            _template.FormBorderStyle = FormBorderStyle.None;
            _template.Dock = DockStyle.Fill;
            _template.Visible = true;
            panel.Controls.Add(_template);

            _template.RightComboBox.ValueMember = _template.LeftComboBox.ValueMember = "Key";
            _template.RightComboBox.DisplayMember = _template.LeftComboBox.DisplayMember = "Value";
        }

        private void PopulateComboBox(string query, ComboBox comboBox)
        {
            using (SqlDataReader reader = _conn.Query(query))
            {
                comboBox.Items.Clear();
                while (reader.Read())
                {
                    KeyValuePair<int, string> pair = new KeyValuePair<int, string>(reader.GetInt32(0), reader["Nombre"].ToString());
                    comboBox.Items.Add(pair);
                }
            }
        }

        private void SetUpSideBoard(TableLayoutPanel inputsContainer, DBConnection conn)
        {
            inputsContainer.Controls.Clear();
            using (SqlDataReader reader = conn.Query("SELECT IdCurso, Nombre, Grado FROM CursoFull"))
            {
                List<Button> buttons = new List<Button>();
                while (reader.Read())
                {
                    int primaryId = reader.GetInt32(0);
                    Button btn = CreateControl(new Button()
                    {
                        Dock = DockStyle.Fill,
                        Text = $"{reader["Nombre"]}, {reader["Grado"]}",
                        TextAlign = ContentAlignment.MiddleCenter,
                        BackColor = _pageColor,
                        FlatStyle = FlatStyle.Flat
                    });
                    buttons.Add(btn);
                    btn.ApplyTheme(_pageColor);

                    btn.Click += (o, s) =>
                    {
                        _selectedPrimaryId = primaryId;
                        btn.SetAsActiveButton(_activeButton, _pageColor);
                        _activeButton = btn;
                        UpdateDisplay();
                    };
                }

                inputsContainer.RowCount = buttons.Count;
                for (int i = 0; i < buttons.Count; i++)
                    inputsContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                for (int i = 0; i < buttons.Count; i++)
                    inputsContainer.Controls.Add(buttons[i], 0, i);
                if (buttons.Count >= 1)
                    buttons[0].PerformClick();
            }
        }

        private void UpdateDisplay()
        {
            string query =
                "SELECT e.IdEstudiante, e.Nombre " +
                "FROM Asignacion a " +
                "INNER JOIN Estudiante e ON a.IdEstudiante=e.IdEstudiante " +
                $"WHERE IdCurso={_selectedPrimaryId}";
            PopulateComboBox(query, _template.RightComboBox);

            query =
                "SELECT IdEstudiante, Nombre " +
                "FROM Estudiante " +
                $"WHERE IdEstudiante NOT IN (SELECT IdEstudiante FROM Asignacion WHERE IdCurso={_selectedPrimaryId})";
            PopulateComboBox(query, _template.LeftComboBox);
        }
    }
}