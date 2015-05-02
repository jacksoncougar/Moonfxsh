using System.Text;

namespace Moonfish.Guerilla.Reflection
{
    public static class StringBuilderExtensions
    {
        public static void AppendSummary( this StringBuilder stringBuilder, string value )
        {
            stringBuilder.AppendLine( "/// <summary>" );
            stringBuilder.AppendLine( string.Format( "/// {0}", value ) );
            stringBuilder.AppendLine( "/// </summary>" );
        }
    }
}