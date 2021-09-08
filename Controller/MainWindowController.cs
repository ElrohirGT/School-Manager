using Controller.Renderers;
using Model;
using System;
using System.Windows.Forms;

namespace Controller
{
    public class MainWindowController : IDisposable
    {
        private readonly DBConnection _conn = new DBConnection();
        private int _activeIndex = 0;
        private Panel _clientPanel;
        private IPageRenderer[] _pageRenderers;
        private Panel[] _pages;

        public MainWindowController(Panel clientPanel, IPageRenderer[] pageRenderers)
        {
            _pages = new Panel[pageRenderers.Length];
            _pageRenderers = pageRenderers;
            _clientPanel = clientPanel;
            for (int i = 0; i < pageRenderers.Length; i++)
            {
                _pages[i] = new Panel() { Dock = DockStyle.Fill, Visible = false };
                pageRenderers[i].RenderPage(_pages[i], _conn);
                clientPanel.Controls.Add(_pages[i]);
            }
            GoToPage(0);
        }

        public void Dispose()
        {
            _conn.Dispose();
            foreach (var item in _pageRenderers)
                item.Dispose();
        }

        public void GoToPage(int index)
        {
            _clientPanel.SuspendLayout();

            _pages[_activeIndex].Visible = false;
            _pageRenderers[index].PopulatePage(_conn);
            _pages[index].Visible = true;

            _activeIndex = index;
            _clientPanel.ResumeLayout();
        }
    }
}