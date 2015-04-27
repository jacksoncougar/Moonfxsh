// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UnitPosturesBlock : UnitPosturesBlockBase
    {
        public UnitPosturesBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 4 )]
    public class UnitPosturesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal OpenTK.Vector3 pillOffset;

        public override int SerializedSize
        {
            get { return 16; }
        }

        internal UnitPosturesBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            name = binaryReader.ReadStringID( );
            pillOffset = binaryReader.ReadVector3( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                binaryWriter.Write( pillOffset );
                return nextAddress;
            }
        }
    };
}