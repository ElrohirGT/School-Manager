using System;
using System.Windows.Forms;

namespace Model.Controls
{
    public class DateTimeInputControl : BaseInputControl
    {
        private DateTimePicker _control;

        public DateTimeInputControl() => _control = new DateTimePicker();

        public override Control Control => _control;

        public override object InputtedValue
        {
            get => _control.Value;
            set
            {
                if (!DateTime.TryParse(value.ToString(), out DateTime result))
                    SetToDefaultValue();
                else
                    _control.Value = result;
            }
        }

        public override void SetToDefaultValue() => _control.Value = DateTime.Now;
    }
}