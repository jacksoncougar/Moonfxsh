using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Sunfish.Forms
{
    /// <summary>
    /// Model for <see cref="NavigationBar"/>
    /// </summary>
    public class AddressBarState : INotifyPropertyChanged
    {
        public AddressBarState(string path)
        {
            Path = path;
        }

        public AddressBarState()
        {
        }

        private string _path;

        /// <summary>
        /// AddressBar text value
        /// </summary>
        public string Path
        {
            get { return _path; }
            set
            {
                if ( _path == value ) return;
                _path = value;
                OnPropertyChanged( );
            }
        }

        private string _searchText;

        /// <summary>
        /// SearchBar text value
        /// </summary>
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if ( _searchText == value ) return;
                _searchText = value;
                OnPropertyChanged( );
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged( [CallerMemberName] string propertyName = null )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}
