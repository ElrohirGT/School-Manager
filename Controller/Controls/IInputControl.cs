using System.Windows.Forms;

namespace Model.Controls
{
    public interface IInputControl
    {
        Control Control { get; }
        object InputtedValue { get; set; }

        object GetDisplayValue();

        void SetToDefaultValue();
    }
}