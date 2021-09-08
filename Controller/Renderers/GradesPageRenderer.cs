using Controller.Renderers.Templates;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Controller.Renderers
{
    public class GradesPageRenderer : BasePageRenderer
    {
        private DataGridView _dataDisplay;
        private DataTable _dataSource = new DataTable();
        private DBConnection _dbConn;
        private object _previousValue;
        private int? _idMaestro = null;
        private Color _pageColor;
        private string _pageTitle;
        private GradesPageTemplate _template;
        private int _selectedPrimaryId = 0;
        private Button _previousActiveButton;

        public GradesPageRenderer(string pageTitle, Color pageColor, int? idMaestro = null)
        {
            _pageColor = pageColor;
            _pageTitle = pageTitle;
            _idMaestro = idMaestro;
        }

        #region Implementing IPageRenderer

        public override void PopulatePage(DBConnection conn) => SetUpSideBoard(_template.InputsContainer, conn);

        public override void RenderPage(Panel panel, DBConnection conn)
        {
            _dbConn = conn;

            _template = new GradesPageTemplate(_pageTitle, _pageColor);
            _template.TopLevel = false;
            _template.FormBorderStyle = FormBorderStyle.None;
            _template.Visible = true;
            _template.Dock = DockStyle.Fill;
            panel.Controls.Add(_template);

            _dataDisplay = _template.DataDisplay;
            _dataDisplay.DataSource = _dataSource;
            _dataDisplay.CellBeginEdit += _dataDisplay_CellBeginEdit;
            _dataDisplay.CellEndEdit += _dataDisplay_CellEndEdit;
        }

        private void SetUpSideBoard(TableLayoutPanel inputsContainer, DBConnection conn)
        {
            inputsContainer.Controls.Clear();
            string query = "SELECT cf.IdCurso, cf.Nombre, cf.Grado FROM CursoFull cf";
            if (_idMaestro.HasValue)
                query += $" INNER JOIN Curso c ON cf.IdCurso = c.IdCurso WHERE c.IdProfesor={_idMaestro.Value}";
            using (SqlDataReader reader = conn.Query(query))
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
                        btn.SetAsActiveButton(_previousActiveButton, _pageColor);
                        _previousActiveButton = btn;
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
            _dataSource.Clear();

            string query =
                "SELECT IdAsignacion, Estudiante, [Nota IU], [Nota IIU], [Nota IIIU], [Nota IVU] " +
                $"FROM AsignacionFull WHERE IdCurso={_selectedPrimaryId}";
            using (var reader = _dbConn.Query(query))
            {
                _dataSource.Load(reader);
            }

            foreach (DataColumn col in _dataSource.Columns)
                col.ReadOnly = !col.ColumnName.StartsWith("Nota");

            _dataDisplay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        #endregion Implementing IPageRenderer

        private void _dataDisplay_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
            => _previousValue = _dataDisplay[e.ColumnIndex, e.RowIndex].Value;

        private void _dataDisplay_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            object value = _dataDisplay[e.ColumnIndex, e.RowIndex].Value;
            if (value.Equals(_previousValue) || !decimal.TryParse(value.ToString(), out decimal unitGrade))
            {
                _dataDisplay[e.ColumnIndex, e.RowIndex].Value = _previousValue;
                return;
            }

            object id = _dataDisplay.Rows[e.RowIndex].Cells[0].Value;
            string fieldName = _dataDisplay.Columns[e.ColumnIndex].Name;

            try
            {
                _dbConn.Update(
                    "Asignacion",
                    new string[] { "IdAsignacion", fieldName },
                    new SqlParameter[] { new SqlParameter("@param0", id), new SqlParameter("@param1", unitGrade) }
                );
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Ocurrió un error al cambiar la nota");
                _dataDisplay[e.ColumnIndex, e.RowIndex].Value = _previousValue;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _dataDisplay.CellEndEdit -= _dataDisplay_CellEndEdit;
            _dataDisplay.CellBeginEdit -= _dataDisplay_CellBeginEdit;
        }
    }
}