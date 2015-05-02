using System.Linq;
using System.Text;

namespace Moonfish.Guerilla.Reflection
{
    public static class AccessModifiersExtensions
    {
        public static string ToTokenString(this AccessModifiers items)
        {
            if ( ( items & AccessModifiers.Any ) == 0 ) return "";
            var value = new StringBuilder( );
            var values = items.ToString( ).Split( ',' ).Select( x=>x.Trim() ).ToList( );
            values.TakeWhile( x => x != values.Last( ) )
                .ToList( )
                .ForEach( x => value.Append( string.Format( "{0} ", x.ToLower( ) ) ) );
            value.Append( string.Format( "{0}", values.LastOrDefault( ) == null ? "" : values.Last( ).ToLower( ) ) );

            return value.ToString( ).Trim( );
        }
    }
}