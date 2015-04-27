// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UnitHudReferenceBlock : UnitHudReferenceBlockBase
    {
        public UnitHudReferenceBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class UnitHudReferenceBlockBase : GuerillaBlock
    {
        [TagReference( "nhdt" )] internal Moonfish.Tags.TagReference newUnitHudInterface;

        public override int SerializedSize
        {
            get { return 8; }
        }

        internal UnitHudReferenceBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            newUnitHudInterface = binaryReader.ReadTagReference( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( newUnitHudInterface );
                return nextAddress;
            }
        }
    };
}