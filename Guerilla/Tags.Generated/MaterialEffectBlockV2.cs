// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MaterialEffectBlockV2 : MaterialEffectBlockV2Base
    {
        public MaterialEffectBlockV2( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 24, Alignment = 4 )]
    public class MaterialEffectBlockV2Base : IGuerilla
    {
        internal OldMaterialEffectMaterialBlock[] oldMaterialsDONOTUSE;
        internal MaterialEffectMaterialBlock[] sounds;
        internal MaterialEffectMaterialBlock[] effects;

        internal MaterialEffectBlockV2Base( BinaryReader binaryReader )
        {
            oldMaterialsDONOTUSE = Guerilla.ReadBlockArray<OldMaterialEffectMaterialBlock>( binaryReader );
            sounds = Guerilla.ReadBlockArray<MaterialEffectMaterialBlock>( binaryReader );
            effects = Guerilla.ReadBlockArray<MaterialEffectMaterialBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<OldMaterialEffectMaterialBlock>( binaryWriter,
                    oldMaterialsDONOTUSE, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<MaterialEffectMaterialBlock>( binaryWriter, sounds, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<MaterialEffectMaterialBlock>( binaryWriter, effects, nextAddress );
                return nextAddress;
            }
        }
    };
}