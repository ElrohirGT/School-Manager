using Model;
using System.Drawing;
using System.Windows.Forms;

namespace Controller.Renderers
{
    public class HomePageRenderer : BasePageRenderer
    {
        private Image _backgroundImage;

        public HomePageRenderer(Image backgroundImage)
        {
            _backgroundImage = backgroundImage;
        }

        public override void PopulatePage(DBConnection dbConn)
        {
        }

        public override void RenderPage(Panel panel, DBConnection dbConn)
        {
            panel.BackgroundImage = _backgroundImage;
            panel.BackgroundImageLayout = ImageLayout.Stretch;

            //LABEL CONTAINER
            var labelContainer = CreateControl(new Panel());
            labelContainer.Dock = DockStyle.Fill;
            labelContainer.BackColor = Color.FromArgb(100, Color.Black);
            panel.Controls.Add(labelContainer);

            //LABEL
            var label = CreateControl(new Label());
            label.Text = "BIENVENIDO";
            label.ForeColor = Color.FromArgb(255, Color.White);
            label.Dock = DockStyle.Fill;
            label.BackColor = Color.Transparent;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Font = new Font(label.Font.FontFamily, 30, FontStyle.Bold);
            labelContainer.Controls.Add(label);
        }
    }
}