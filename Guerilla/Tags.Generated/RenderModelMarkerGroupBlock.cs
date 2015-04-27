// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RenderModelMarkerGroupBlock : RenderModelMarkerGroupBlockBase
    {
        public RenderModelMarkerGroupBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 12, Alignment = 4 )]
    public class RenderModelMarkerGroupBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal RenderModelMarkerBlock[] markers;

        public override int SerializedSize
        {
            get { return 12; }
        }

        internal RenderModelMarkerGroupBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            name = binaryReader.ReadStringID( );
            markers = Guerilla.ReadBlockArray<RenderModelMarkerBlock>( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                nextAddress = Guerilla.WriteBlockArray<RenderModelMarkerBlock>( binaryWriter, markers, nextAddress );
                return nextAddress;
            }
        }
    };
}