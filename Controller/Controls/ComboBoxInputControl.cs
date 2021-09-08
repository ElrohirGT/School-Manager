using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Model.Controls
{
    public class ComboBoxInputControl : BaseInputControl
    {
        private ComboBox _control = new ComboBox() { DropDownStyle = ComboBoxStyle.DropDownList };
        private BindingSource _source = new BindingSource();
        private List<KeyValuePair<int, object>> _values = new List<KeyValuePair<int, object>>();

        public ComboBoxInputControl()
        {
            _control.DisplayMember = "Value";
            _control.ValueMember = "Key";
            _source.DataSource = _values;
            _control.DataSource = _source;
        }

        public void UpdateSelection(SqlDataReader subTableDataReader)
        {
            _values.Clear();
            while (subTableDataReader.Read())
            {
                _values.Add(
                    new KeyValuePair<int, object>(
                        subTableDataReader.GetInt32(0),
                        subTableDataReader["Nombre"]
                    )
                );
            }
            _source.ResetBindings(false);
        }

        public override Control Control => _control;

        public override object GetDisplayValue() => ((KeyValuePair<int, object>)_control.SelectedItem).Value;

        public override object InputtedValue
        {
            get => _control.SelectedValue;
            set
            {
                int index = _values.FindIndex((v) => v.Value.Equals(value));
                if (index == -1)
                    SetToDefaultValue();
                else
                    _control.SelectedItem = _values[index];
            }
        }

        public override void SetToDefaultValue()
        {
            _control.SelectedItem = null;
            _control.SelectedText = "--Please select a value--";
        }
    }
}