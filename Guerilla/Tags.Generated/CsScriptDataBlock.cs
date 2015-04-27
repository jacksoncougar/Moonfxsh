// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CsScriptDataBlock : CsScriptDataBlockBase
    {
        public CsScriptDataBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 128, Alignment = 4 )]
    public class CsScriptDataBlockBase : GuerillaBlock
    {
        internal CsPointSetBlock[] pointSets;
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 128; }
        }

        internal CsScriptDataBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            pointSets = Guerilla.ReadBlockArray<CsPointSetBlock>( binaryReader );
            invalidName_ = binaryReader.ReadBytes( 120 );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<CsPointSetBlock>( binaryWriter, pointSets, nextAddress );
                binaryWriter.Write( invalidName_, 0, 120 );
                return nextAddress;
            }
        }
    };
}