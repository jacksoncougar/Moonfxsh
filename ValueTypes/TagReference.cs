using System.Runtime.InteropServices;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType( MoonfishFieldType.FieldTagReference )]
    [StructLayout( LayoutKind.Sequential, Size = 8 )]
    public struct TagReference
    {
        public readonly TagClass Class;
        public readonly TagIdent Ident;

        public TagReference( TagClass tagClass, TagIdent tagID )
        {
            Class = tagClass;
            Ident = tagID;
        }

        public override string ToString( )
        {
            return string.Format( "{0}, {1}", Class, Ident );
        }
    }
}