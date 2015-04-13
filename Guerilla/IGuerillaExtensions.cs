using System.IO;
using Fasterflect;
using Moonfish.Tags;

namespace Moonfish.Guerilla
{
    public static class IGuerillaExtensions
    {
        public static int GetSize( this IGuerilla block )
        {
            return Guerilla.SizeOf( block.GetType( ) );
        }

        public static int GetAlignment( this IGuerilla block )
        {
            return Guerilla.AlignmentOf( block.GetType( ) );
        }

        public static void Write( this IGuerilla block, BinaryWriter binaryWriter )
        {
            binaryWriter.WritePadding( block.GetAlignment(  ) );
            block.Write( binaryWriter, (int)binaryWriter.BaseStream.Position + block.GetSize( ) );
        }
    };
}