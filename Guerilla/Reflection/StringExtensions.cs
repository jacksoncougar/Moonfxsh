using System.Linq;

namespace Moonfish.Guerilla.Reflection
{
    public static class StringExtensions
    {
        public static string Tab( this string value, ref int tabCount, int tabSize = 4 )
        {
            var openingBraceCount = value.Trim( ).Count( x => x == '{' );
            var closingBraceCount = value.Trim( ).Count( x => x == '}' );
            var netTab = openingBraceCount - closingBraceCount;
            tabCount = netTab < 0 ? tabCount + netTab : tabCount;
            var tab = new string( ' ', tabCount * tabSize );
            tabCount = netTab > 0 ? tabCount + netTab : tabCount;
            return tab + value;
        }
    }
}