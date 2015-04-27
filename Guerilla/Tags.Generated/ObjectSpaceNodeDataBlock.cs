// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ObjectSpaceNodeDataBlock : ObjectSpaceNodeDataBlockBase
    {
        public ObjectSpaceNodeDataBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 28, Alignment = 4 )]
    public class ObjectSpaceNodeDataBlockBase : GuerillaBlock
    {
        internal short nodeIndex;
        internal ComponentFlags componentFlags;
        internal QuantizedOrientationStructBlock orientation;

        public override int SerializedSize
        {
            get { return 28; }
        }

        internal ObjectSpaceNodeDataBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            nodeIndex = binaryReader.ReadInt16( );
            componentFlags = ( ComponentFlags ) binaryReader.ReadInt16( );
            orientation = new QuantizedOrientationStructBlock( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( nodeIndex );
                binaryWriter.Write( ( Int16 ) componentFlags );
                orientation.Write( binaryWriter );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum ComponentFlags : short
        {
            Rotation = 1,
            Translation = 2,
            Scale = 4,
        };
    };
}