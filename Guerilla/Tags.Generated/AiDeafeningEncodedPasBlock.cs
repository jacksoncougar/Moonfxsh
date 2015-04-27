// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AiDeafeningEncodedPasBlock : AiDeafeningEncodedPasBlockBase
    {
        public AiDeafeningEncodedPasBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class AiDeafeningEncodedPasBlockBase : GuerillaBlock
    {
        internal int invalidName_;

        public override int SerializedSize
        {
            get { return 4; }
        }

        internal AiDeafeningEncodedPasBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            invalidName_ = binaryReader.ReadInt32( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( invalidName_ );
                return nextAddress;
            }
        }
    };
}