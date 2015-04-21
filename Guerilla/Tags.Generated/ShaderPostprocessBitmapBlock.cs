// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessBitmapBlock : ShaderPostprocessBitmapBlockBase
    {
        public ShaderPostprocessBitmapBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 10, Alignment = 4 )]
    public class ShaderPostprocessBitmapBlockBase : IGuerilla
    {
        internal byte parameterIndex;
        internal byte flags;
        internal int bitmapGroupIndex;
        internal float logBitmapDimension;

        internal ShaderPostprocessBitmapBlockBase( BinaryReader binaryReader )
        {
            parameterIndex = binaryReader.ReadByte( );
            flags = binaryReader.ReadByte( );
            bitmapGroupIndex = binaryReader.ReadInt32( );
            logBitmapDimension = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( parameterIndex );
                binaryWriter.Write( flags );
                binaryWriter.Write( bitmapGroupIndex );
                binaryWriter.Write( logBitmapDimension );
                return nextAddress;
            }
        }
    };
}