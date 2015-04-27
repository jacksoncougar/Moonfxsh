// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RenderModelNodeMapBlock : RenderModelNodeMapBlockBase
    {
        public RenderModelNodeMapBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 1, Alignment = 4 )]
    public class RenderModelNodeMapBlockBase : GuerillaBlock
    {
        internal byte nodeIndex;

        public override int SerializedSize
        {
            get { return 1; }
        }

        internal RenderModelNodeMapBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            nodeIndex = binaryReader.ReadByte( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( nodeIndex );
                return nextAddress;
            }
        }
    };
}