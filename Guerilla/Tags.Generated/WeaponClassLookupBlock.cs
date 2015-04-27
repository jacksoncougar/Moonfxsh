// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class WeaponClassLookupBlock : WeaponClassLookupBlockBase
    {
        public WeaponClassLookupBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class WeaponClassLookupBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID weaponName;
        internal Moonfish.Tags.StringID weaponClass;

        public override int SerializedSize
        {
            get { return 8; }
        }

        internal WeaponClassLookupBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            weaponName = binaryReader.ReadStringID( );
            weaponClass = binaryReader.ReadStringID( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( weaponName );
                binaryWriter.Write( weaponClass );
                return nextAddress;
            }
        }
    };
}