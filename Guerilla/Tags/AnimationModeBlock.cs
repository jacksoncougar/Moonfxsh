// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationModeBlock : AnimationModeBlockBase
    {
        public AnimationModeBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 20, Alignment = 4 )]
    public class AnimationModeBlockBase : IGuerilla
    {
        internal Moonfish.Tags.StringID label;
        internal WeaponClassBlock[] weaponClassAABBCC;
        internal AnimationIkBlock[] modeIkAABBCC;

        internal AnimationModeBlockBase( BinaryReader binaryReader )
        {
            label = binaryReader.ReadStringID( );
            weaponClassAABBCC = Guerilla.ReadBlockArray<WeaponClassBlock>( binaryReader );
            modeIkAABBCC = Guerilla.ReadBlockArray<AnimationIkBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( label );
                nextAddress = Guerilla.WriteBlockArray<WeaponClassBlock>( binaryWriter, weaponClassAABBCC, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<AnimationIkBlock>( binaryWriter, modeIkAABBCC, nextAddress );
                return nextAddress;
            }
        }
    };
}