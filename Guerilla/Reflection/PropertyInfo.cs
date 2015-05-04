using System.Text;

namespace Moonfish.Guerilla.Reflection
{
    public class PropertyInfo
    {
        public AccessModifiers AccessModifiers { get; set; }
        public string Name { get; set; }
        public string Returns { get; set; }
        public string SetBody { get; set; }
        public string GetBody { get; set; }

        public override string ToString( )
        {
            var hasSetter = SetBody != null;
            var hasGetter = GetBody != null;

            var builder = new StringBuilder(  );
            builder.Append( string.Format( "{0} {1} {2} ", AccessModifiers.ToTokenString( ), Returns, Name ) );
            var indent = 0;
            builder.Append( "{".Tab( ref indent ) );
            if ( hasGetter )
            {
                var auto = string.IsNullOrWhiteSpace( GetBody );
                builder.Append( auto ? " get; " : string.Format( " get {{ {0} }}", GetBody ) );
            }
            if ( hasSetter )
            {
                var auto = string.IsNullOrWhiteSpace( SetBody );
                builder.Append( auto ? " set; " : string.Format( " set {{ {0} }}", GetBody ) );
            }
            builder.Append( " }".Tab( ref indent ) );
            return builder.ToString( );
        }
    }
}