using Controller.Renderers.Templates;
using Model;
using Model.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Controller.Renderers
{
    public class BasicCRUDPageRenderer : BasePageRenderer
    {
        private readonly List<string> _fields = new List<string>();
        private List<KeyValuePair<ComboBoxInputControl, string>> _comboboxQueries = new List<KeyValuePair<ComboBoxInputControl, string>>();
        private readonly List<BaseInputControl> _inputControls = new List<BaseInputControl>();
        private DataGridView _dataDisplay;
        private DataTable _dataSource = new DataTable();
        private BasicCRUDPageTemplate _template;

        public BasicCRUDPageRenderer(string displayTitle, string tableName, string displayTableName, Color pageColor)
        {
            DisplayTitle = displayTitle;
            DisplayTableName = displayTableName;

            PageColor = pageColor;
            TableName = tableName;
        }

        public string DisplayTitle { get; }
        protected string DisplayTableName { get; }
        protected Color PageColor { get; set; }
        protected string TableName { get; set; }

        #region Implementing IPageRenderer

        public override void PopulatePage(DBConnection dbConn)
        {
            _dataSource.Clear();
            using (SqlDataReader reader = dbConn.Query($"SELECT * FROM [{DisplayTableName}]"))
            {
                _dataSource.Load(reader);
            }
            foreach (var pair in _comboboxQueries)
            {
                using (SqlDataReader reader = dbConn.Query(pair.Value))
                {
                    pair.Key.UpdateSelection(reader);
                }
            }
        }

        public override void RenderPage(Panel panel, DBConnection conn)
        {
            _template = new BasicCRUDPageTemplate(DisplayTitle, PageColor);
            _template.TopLevel = false;
            _template.FormBorderStyle = FormBorderStyle.None;
            _template.Dock = DockStyle.Fill;
            _template.Visible = true;
            panel.Controls.Add(_template);

            SetUpSideBoard(_template.InputsContainer, conn);

            _template.AddButton.Click += Addbutton_Click;
            _template.EditButton.Click += EditButton_Click;
            _template.DeleteButton.Click += DeleteButton_Click;
            _template.DataDisplay.SelectionChanged += DataDisplay_SelectionChanged;

            _dataDisplay = _template.DataDisplay;
            _dataDisplay.DataSource = _dataSource;
        }

        private void SetUpSideBoard(TableLayoutPanel inputsContainer, DBConnection dbConn)
        {
            using (SqlDataReader dataReader = dbConn.Query($"SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='{TableName}'"))
            {
                _fields.Clear();
                _inputControls.Clear();
                int numberOfFields = 0;
                List<Label> labels = new List<Label>();
                List<Control> inputs = new List<Control>();

                while (dataReader.Read())
                {
                    string columnName = (string)dataReader["COLUMN_NAME"];
                    string columnType = (string)dataReader["DATA_TYPE"];
                    _fields.Add(columnName);

                    if (columnName == $"Id{TableName}")
                        continue;
                    ++numberOfFields;
                    SqlDataReader subTableDataReader = null;
                    string subquery = string.Empty;
                    if (columnName.StartsWith("Id"))
                    {
                        string subTableName = columnName.Substring(2);
                        columnName = subTableName;
                        subquery = $"SELECT * FROM {subTableName}";
                        subTableDataReader = dbConn.Query(subquery);
                    }

                    Label label = CreateControl(new Label());
                    label.Text = $"{columnName}:";
                    label.Dock = DockStyle.Fill;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.ForeColor = Color.White;
                    label.AutoSize = false;
                    labels.Add(label);

                    BaseInputControl input = BaseInputControl.CreateFromType(columnType, subTableDataReader);
                    var inputControl = CreateControl(input.Control);
                    inputControl.Dock = DockStyle.Fill;
                    inputControl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                    _inputControls.Add(input);
                    subTableDataReader?.Close();
                    inputs.Add(inputControl);

                    if (input is ComboBoxInputControl)
                    {
                        _comboboxQueries.Add(new KeyValuePair<ComboBoxInputControl, string>((ComboBoxInputControl)input, subquery));
                    }
                }
                inputsContainer.RowCount = numberOfFields + 5;
                float rowHeight = 100 / (numberOfFields + 5);
                for (int i = 0; i < numberOfFields + 5; i++)
                    inputsContainer.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeight));
                for (int i = 0; i < numberOfFields; i++)
                {
                    inputsContainer.Controls.Add(labels[i], 0, i);
                    inputsContainer.Controls.Add(inputs[i], 1, i);
                }
            }
        }

        #endregion Implementing IPageRenderer

        #region Buttons Events

        private void Addbutton_Click(object sender, EventArgs e)
        {
            List<object> values = GetValues();
            SqlParameter[] parameters = ConstructParameters(values.ToArray(), true);
            string[] fieldNames = _fields.GetRange(1, _fields.Count - 1).ToArray();

            try
            {
                int id;
                using (DBConnection conn = new DBConnection())
                {
                    id = conn.Insert(TableName, fieldNames, parameters);
                }
                values.Insert(0, id);
                _dataSource.Rows.Add(GetValues(id));

                foreach (var control in _inputControls)
                    control.SetToDefaultValue();
                MessageBox.Show("Data Successfully Inserted!");
            }
            catch (SqlException err)
            {
                MessageBox.Show($"An error ocurred inserting the data! {err.Message}");
            }
        }

        private SqlParameter[] ConstructParameters(object[] values, bool createId = true)
        {
            SqlParameter[] parameters;
            if (createId)
            {
                parameters = new SqlParameter[values.Length];
                for (int i = 0; i < values.Length; i++)
                    parameters[i] = new SqlParameter($"@param{i}", values[i]);
            }
            else
            {
                parameters = new SqlParameter[values.Length + 1];
                parameters[0] = new SqlParameter("@param0", _dataDisplay.SelectedRows[0].Cells[0].Value);

                for (int i = 0; i < values.Length; i++)
                    parameters[i + 1] = new SqlParameter($"@param{i + 1}", values[i]);
            }
            return parameters;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (_dataDisplay.SelectedRows.Count <= 0)
                return;

            string selectedId = _dataDisplay.SelectedRows[0].Cells[0].Value.ToString();
            int selectedIndex = _dataDisplay.SelectedRows[0].Index;

            try
            {
                using (DBConnection conn = new DBConnection())
                {
                    conn.Delete(TableName, selectedId);
                    _dataSource.Rows.RemoveAt(selectedIndex);
                }
                MessageBox.Show("Data Successfully Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "An error ocurred deleting the data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (_dataDisplay.SelectedRows.Count == 0)
                return;

            List<object> values = GetValues();
            SqlParameter[] parameters = ConstructParameters(values.ToArray(), createId: false);
            string[] fieldNames = _fields.ToArray();

            object selectedId = _dataDisplay.SelectedRows[0].Cells[0].Value;
            int selectedIndex = _dataDisplay.SelectedRows[0].Index;

            try
            {
                using (DBConnection conn = new DBConnection())
                {
                    conn.Update(TableName, fieldNames, parameters);

                    object[] rowValues = GetValues(selectedId);
                    DataRow row = _dataSource.NewRow();

                    values.Insert(0, selectedId);
                    row.ItemArray = rowValues;
                    _dataSource.Rows.RemoveAt(selectedIndex);
                    _dataSource.Rows.InsertAt(row, selectedIndex);
                }
                MessageBox.Show("Data Successfully Updated!");
            }
            catch (SqlException err)
            {
                MessageBox.Show($"An error ocurred updating the data! {err.Message}");
            }
        }

        private List<object> GetValues()
        {
            object[] values = new object[_inputControls.Count];
            for (int i = 0; i < _inputControls.Count; i++)
                values[i] = _inputControls[i].InputtedValue;
            return new List<object>(values);
        }

        private object[] GetValues(object itemId)
        {
            object[] items = new object[_inputControls.Count + 1];
            items[0] = itemId;
            for (int i = 0; i < _inputControls.Count; i++)
                items[i + 1] = _inputControls[i].GetDisplayValue();
            return items;
        }

        #endregion Buttons Events

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            _template.AddButton.Click -= Addbutton_Click;
            _template.EditButton.Click -= EditButton_Click;
            _template.DeleteButton.Click -= DeleteButton_Click;
            _template.DataDisplay.SelectionChanged -= DataDisplay_SelectionChanged;
        }

        private void DataDisplay_SelectionChanged(object sender, EventArgs e)
        {
            if (_dataDisplay.SelectedRows.Count <= 0)
                return;

            DataGridViewCellCollection selectedRows = _dataDisplay.SelectedRows[0].Cells;
            for (int i = 1; i < selectedRows.Count; i++)
            {
                DataGridViewCell cell = selectedRows[i];
                _inputControls[i - 1].InputtedValue = cell.Value.ToString();
            }
        }
    }
}