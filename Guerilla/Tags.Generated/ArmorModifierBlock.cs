// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ArmorModifierBlock : ArmorModifierBlockBase
    {
        public ArmorModifierBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class ArmorModifierBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal float damageMultiplier;

        public override int SerializedSize
        {
            get { return 8; }
        }

        internal ArmorModifierBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            name = binaryReader.ReadStringID( );
            damageMultiplier = binaryReader.ReadSingle( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                binaryWriter.Write( damageMultiplier );
                return nextAddress;
            }
        }
    };
}