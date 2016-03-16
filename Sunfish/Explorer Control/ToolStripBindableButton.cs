using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sunfish
{
    class ToolStripBindableButton : ToolStripButton, IBindableComponent
    {
        [Browsable(true)]
        public BindingContext BindingContext { get; set; } = new BindingContext();

        ControlBindingsCollection dataBindings;
        [Browsable(true)]
        public ControlBindingsCollection DataBindings
        {
            get
            {
                if (dataBindings == null) dataBindings = new ControlBindingsCollection(this);
                return dataBindings;
            }
        }
    }
}
