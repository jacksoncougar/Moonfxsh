using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sunfish
{
    public partial class TagListView : ListView, INotifyPropertyChanged
    {
        public TagListView()
        {
            InitializeComponent();
        }

        public new View View
        {
            get { return base.View; }
            set
            {
                if (base.View != value)
                {
                    base.View = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(View)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
