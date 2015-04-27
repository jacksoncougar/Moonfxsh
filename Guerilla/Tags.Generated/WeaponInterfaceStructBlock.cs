// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class WeaponInterfaceStructBlock : WeaponInterfaceStructBlockBase
    {
        public WeaponInterfaceStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 32, Alignment = 4 )]
    public class WeaponInterfaceStructBlockBase : GuerillaBlock
    {
        internal WeaponSharedInterfaceStructBlock sharedInterface;
        internal WeaponFirstPersonInterfaceBlock[] firstPerson;
        [TagReference( "nhdt" )] internal Moonfish.Tags.TagReference newHudInterface;

        public override int SerializedSize
        {
            get { return 32; }
        }

        internal WeaponInterfaceStructBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            sharedInterface = new WeaponSharedInterfaceStructBlock( binaryReader );
            firstPerson = Guerilla.ReadBlockArray<WeaponFirstPersonInterfaceBlock>( binaryReader );
            newHudInterface = binaryReader.ReadTagReference( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                sharedInterface.Write( binaryWriter );
                nextAddress = Guerilla.WriteBlockArray<WeaponFirstPersonInterfaceBlock>( binaryWriter, firstPerson,
                    nextAddress );
                binaryWriter.Write( newHudInterface );
                return nextAddress;
            }
        }
    };
}