// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ObjectWidgetBlock : ObjectWidgetBlockBase
    {
        public ObjectWidgetBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class ObjectWidgetBlockBase : GuerillaBlock
    {
        [TagReference( "null" )] internal Moonfish.Tags.TagReference type;

        public override int SerializedSize
        {
            get { return 8; }
        }

        internal ObjectWidgetBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            type = binaryReader.ReadTagReference( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( type );
                return nextAddress;
            }
        }
    };
}