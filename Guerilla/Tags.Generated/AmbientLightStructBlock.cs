// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AmbientLightStructBlock : AmbientLightStructBlockBase
    {
        public AmbientLightStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 32, Alignment = 4 )]
    public class AmbientLightStructBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ColorR8G8B8 minLightmapSample;
        internal Moonfish.Tags.ColorR8G8B8 maxLightmapSample;
        internal MappingFunctionBlock function;

        public override int SerializedSize
        {
            get { return 32; }
        }

        internal AmbientLightStructBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            minLightmapSample = binaryReader.ReadColorR8G8B8( );
            maxLightmapSample = binaryReader.ReadColorR8G8B8( );
            function = new MappingFunctionBlock( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( minLightmapSample );
                binaryWriter.Write( maxLightmapSample );
                function.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}