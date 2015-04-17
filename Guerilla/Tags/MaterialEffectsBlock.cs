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
        public static readonly TagClass Foot = ( TagClass ) "foot";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute( "foot" )]
    public partial class MaterialEffectsBlock : MaterialEffectsBlockBase
    {
        public MaterialEffectsBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class MaterialEffectsBlockBase : IGuerilla
    {
        internal MaterialEffectBlockV2[] effects;

        internal MaterialEffectsBlockBase( BinaryReader binaryReader )
        {
            effects = Guerilla.ReadBlockArray<MaterialEffectBlockV2>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<MaterialEffectBlockV2>( binaryWriter, effects, nextAddress );
                return nextAddress;
            }
        }
    };
}