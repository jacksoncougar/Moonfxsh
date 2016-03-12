using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Moonfish.Forms.TagBlock_Editor
{
    /// <summary>
    /// Interaction logic for Addressbar.xaml
    /// </summary>
    public partial class Addressbar : UserControl
    {
        [Browsable(true)]
        public event EventHandler<string> AddressSubmitted;
        [Browsable(true)]
        public event EventHandler<string> SearchSubmitted;

        public Addressbar()
        {
            InitializeComponent();
        }

        public void DisplayPath( string path )
        {
            PathBox.Text = path;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddressSubmitted?.Invoke(sender, PathBox.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SearchSubmitted?.Invoke(sender, SearchBox.Text);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var path = PathBox.Text;
            var levels = CachePath.GetDirectoryLevelCount( path );
            if ( levels >= 1 )
                path = CachePath.GetDirectoryLevel( path, levels - 1 );
            PathBox.Text = path;
            AddressSubmitted?.Invoke(sender, PathBox.Text);
        }
    }
}
