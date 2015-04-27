// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Gldf = ( TagClass ) "gldf";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute( "gldf" )]
    public partial class ChocolateMountainBlock : ChocolateMountainBlockBase
    {
        public ChocolateMountainBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class ChocolateMountainBlockBase : GuerillaBlock
    {
        internal LightingVariablesBlock[] lightingVariables;

        public override int SerializedSize
        {
            get { return 8; }
        }

        internal ChocolateMountainBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            lightingVariables = Guerilla.ReadBlockArray<LightingVariablesBlock>( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<LightingVariablesBlock>( binaryWriter, lightingVariables,
                    nextAddress );
                return nextAddress;
            }
        }
    };
}