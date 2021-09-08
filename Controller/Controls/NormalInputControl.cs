using System.Windows.Forms;

namespace Model.Controls
{
    public class NormalInputControl : BaseInputControl
    {
        private TextBox _control;

        public NormalInputControl() => _control = new TextBox();

        public override Control Control => _control;

        public override object InputtedValue
        {
            get => _control.Text;
            set => _control.Text = value.ToString();
        }

        public override void SetToDefaultValue() => _control.Text = string.Empty;
    }
}