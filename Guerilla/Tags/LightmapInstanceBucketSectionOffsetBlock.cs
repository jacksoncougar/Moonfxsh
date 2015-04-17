// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightmapInstanceBucketSectionOffsetBlock : LightmapInstanceBucketSectionOffsetBlockBase
    {
        public LightmapInstanceBucketSectionOffsetBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 2, Alignment = 4 )]
    public class LightmapInstanceBucketSectionOffsetBlockBase : IGuerilla
    {
        internal short sectionOffset;

        internal LightmapInstanceBucketSectionOffsetBlockBase( BinaryReader binaryReader )
        {
            sectionOffset = binaryReader.ReadInt16( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( sectionOffset );
                return nextAddress;
            }
        }
    };
}