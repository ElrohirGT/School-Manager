using System.Drawing;
using System.Windows.Forms;

namespace Controller
{
    public static class ExtensionMethods
    {
        public static void ApplyTheme(this Button btn, Color accentColor)
        {
            btn.BackColor = accentColor;
            btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(accentColor);
            btn.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(accentColor);
        }

        public static void SetAsActiveButton(this Button newActiveButton, Button previousActiveButton, Color accentColor)
        {
            if (previousActiveButton != null)
                previousActiveButton.BackColor = accentColor;
            newActiveButton.BackColor = newActiveButton.FlatAppearance.MouseOverBackColor;
        }
    }
}