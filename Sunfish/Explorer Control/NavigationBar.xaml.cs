using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Sunfish.Forms
{
    /// <summary>
    ///     Interaction logic for Addressbar.xaml
    /// </summary>
    public partial class NavigationBar
    {
        public NavigationBar( )
        {
            InitializeComponent( );
        }

        public AddressBarState State { get; }

        /// <summary>
        ///     Occurs when the <see cref="AddressBox" /> value is submitted for processing
        /// </summary>
        [Browsable( true )]
        public event EventHandler<string> AddressSubmitted;

        public void DisplayPath( string path )
        {
            AddressBox.Text = path;
        }

        /// <summary>
        ///     Occurs when the <see cref="SearchBox" /> value is submitted for processing
        /// </summary>
        [Browsable( true )]
        public event EventHandler<string> SearchSubmitted;

        private void Button_Click( object sender, RoutedEventArgs e )
        {
            AddressSubmitted?.Invoke( sender, AddressBox.Text );
        }

        private void Button_Click_1( object sender, RoutedEventArgs e )
        {
            SearchSubmitted?.Invoke( sender, SearchBox.Text );
        }

        private void Button_Click_2( object sender, RoutedEventArgs e )
        {
            var path = AddressBox.Text;
            var levels = CachePath.GetDirectoryLevelCount( path );
            if ( levels >= 1 )
                path = CachePath.GetDirectoryLevel( path, levels - 1 );
            AddressBox.Text = path;
            AddressSubmitted?.Invoke( sender, AddressBox.Text );
        }

        private void SearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if ( e.Key == Key.Enter )
            {
                SearchSubmitted?.Invoke(sender, SearchBox.Text);
            }
        }

        private void AddressBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddressSubmitted?.Invoke(sender, SearchBox.Text);
            }
        }
    }
}