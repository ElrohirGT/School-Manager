using System.Windows.Forms;

namespace Model.Controls
{
    public abstract class BaseInputControl : IInputControl
    {
        public abstract Control Control { get; }

        public abstract object InputtedValue { get; set; }

        public static BaseInputControl CreateFromType(string fieldType, System.Data.SqlClient.SqlDataReader subTableDataReader)
        {
            if (subTableDataReader != null)
                return new ComboBoxInputControl();
            switch (fieldType)
            {
                case "datetime":
                    return new DateTimeInputControl();

                default:
                    return new NormalInputControl();
            }
        }

        public virtual object GetDisplayValue() => InputtedValue;

        public abstract void SetToDefaultValue();
    }
}