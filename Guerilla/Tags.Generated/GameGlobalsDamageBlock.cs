// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GameGlobalsDamageBlock : GameGlobalsDamageBlockBase
    {
        public GameGlobalsDamageBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class GameGlobalsDamageBlockBase : GuerillaBlock
    {
        internal DamageGroupBlock[] damageGroups;

        public override int SerializedSize
        {
            get { return 8; }
        }

        internal GameGlobalsDamageBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            damageGroups = Guerilla.ReadBlockArray<DamageGroupBlock>( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<DamageGroupBlock>( binaryWriter, damageGroups, nextAddress );
                return nextAddress;
            }
        }
    };
}