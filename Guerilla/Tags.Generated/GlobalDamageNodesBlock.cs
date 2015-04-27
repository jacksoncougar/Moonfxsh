// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalDamageNodesBlock : GlobalDamageNodesBlockBase
    {
        public GlobalDamageNodesBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 4 )]
    public class GlobalDamageNodesBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;

        public override int SerializedSize
        {
            get { return 16; }
        }

        internal GlobalDamageNodesBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            invalidName_ = binaryReader.ReadBytes( 2 );
            invalidName_0 = binaryReader.ReadBytes( 2 );
            invalidName_1 = binaryReader.ReadBytes( 12 );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( invalidName_, 0, 2 );
                binaryWriter.Write( invalidName_0, 0, 2 );
                binaryWriter.Write( invalidName_1, 0, 12 );
                return nextAddress;
            }
        }
    };
}