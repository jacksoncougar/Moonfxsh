// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalGeometrySectionVertexBufferBlock : GlobalGeometrySectionVertexBufferBlockBase
    {
        public GlobalGeometrySectionVertexBufferBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 32, Alignment = 4 )]
    public class GlobalGeometrySectionVertexBufferBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.VertexBuffer vertexBuffer;

        public override int SerializedSize
        {
            get { return 32; }
        }

        internal GlobalGeometrySectionVertexBufferBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            vertexBuffer = binaryReader.ReadVertexBuffer( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( vertexBuffer );
                return nextAddress;
            }
        }
    };
}