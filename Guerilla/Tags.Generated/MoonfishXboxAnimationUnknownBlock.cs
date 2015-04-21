// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MoonfishXboxAnimationUnknownBlock : MoonfishXboxAnimationUnknownBlockBase
    {
        public MoonfishXboxAnimationUnknownBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 24, Alignment = 4 )]
    public class MoonfishXboxAnimationUnknownBlockBase : IGuerilla
    {
        internal int unknown1;
        internal int unknown2;
        internal int unknown3;
        internal int unknown4;
        internal int unknown5;
        internal int unknown6;

        internal MoonfishXboxAnimationUnknownBlockBase( BinaryReader binaryReader )
        {
            unknown1 = binaryReader.ReadInt32( );
            unknown2 = binaryReader.ReadInt32( );
            unknown3 = binaryReader.ReadInt32( );
            unknown4 = binaryReader.ReadInt32( );
            unknown5 = binaryReader.ReadInt32( );
            unknown6 = binaryReader.ReadInt32( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( unknown1 );
                binaryWriter.Write( unknown2 );
                binaryWriter.Write( unknown3 );
                binaryWriter.Write( unknown4 );
                binaryWriter.Write( unknown5 );
                binaryWriter.Write( unknown6 );
                return nextAddress;
            }
        }
    };
}