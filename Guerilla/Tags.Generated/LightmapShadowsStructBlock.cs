// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightmapShadowsStructBlock : LightmapShadowsStructBlockBase
    {
        public LightmapShadowsStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class LightmapShadowsStructBlockBase : GuerillaBlock
    {
        internal MappingFunctionBlock function1;

        public override int SerializedSize
        {
            get { return 8; }
        }

        internal LightmapShadowsStructBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            function1 = new MappingFunctionBlock( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                function1.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}