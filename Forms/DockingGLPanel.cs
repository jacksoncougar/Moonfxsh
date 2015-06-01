using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using WeifenLuo.WinFormsUI.Docking;

namespace Moonfish.Forms
{
    public partial class DockingGLPanel : DockPanel
    {
        private GLControl glControl;

        public DockingGLPanel(Action ContextCreatedCallback)
        {
            InitializeComponent();

#if DEBUG
            glControl = new GLControl(GraphicsMode.Default, 4,3, GraphicsContextFlags.Debug);
#else
            glControl = new GLControl();
#endif
            glControl.Load += delegate
            {
                ContextCreatedCallback();
            };
            
            glControl.Dock = DockStyle.Fill;
            Controls.Add( glControl );
        }

        public void SwapBuffers( )
        {
            glControl.SwapBuffers(  );
        }
    }
}
