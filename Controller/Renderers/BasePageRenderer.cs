using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controller.Renderers
{
    public abstract class BasePageRenderer : IPageRenderer
    {
        private List<Control> _controls = new List<Control>();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BasePageRenderer()
        {
            Dispose(false);
        }

        protected List<T> CreateControls<T>(List<T> controls) where T : Control
        {
            _controls.AddRange(controls);
            return controls;
        }

        protected T CreateControl<T>(T control) where T : Control
        {
            _controls.Add(control);
            return control;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                foreach (var control in _controls)
                    control.Dispose();
        }

        public abstract void PopulatePage(DBConnection conn);

        public abstract void RenderPage(Panel panel, DBConnection conn);
    }
}