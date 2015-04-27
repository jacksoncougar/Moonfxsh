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

        public static void Write( this GuerillaBlock block, BinaryWriter binaryWriter )
        {
            block.Write( binaryWriter, ( int ) binaryWriter.BaseStream.Position + block.SerializedSize );
        }

        public static void Write(this BinaryWriter binaryWriter, GuerillaBlock block)
        {
            block.Write(binaryWriter, (int)binaryWriter.BaseStream.Position + block.SerializedSize);
        }
    };
}