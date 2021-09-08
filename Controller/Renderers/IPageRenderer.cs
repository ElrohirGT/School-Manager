using Model;
using System;
using System.Windows.Forms;

namespace Controller.Renderers
{
    public interface IPageRenderer : IDisposable
    {
        void RenderPage(Panel panel, DBConnection dbConn);

        void PopulatePage(DBConnection dbConn);
    }
}