// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DamageGroupBlock : DamageGroupBlockBase
    {
        public DamageGroupBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 12, Alignment = 4 )]
    public class DamageGroupBlockBase : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal ArmorModifierBlock[] armorModifiers;

        internal DamageGroupBlockBase( BinaryReader binaryReader )
        {
            name = binaryReader.ReadStringID( );
            armorModifiers = Guerilla.ReadBlockArray<ArmorModifierBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                nextAddress = Guerilla.WriteBlockArray<ArmorModifierBlock>( binaryWriter, armorModifiers, nextAddress );
                return nextAddress;
            }
        }
    };
}