// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class FlightReferenceBlock : FlightReferenceBlockBase
    {
        public FlightReferenceBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class FlightReferenceBlockBase : GuerillaBlock
    {
        internal short flightHintIndex;
        internal short poitIndex;

        public override int SerializedSize
        {
            get { return 4; }
        }

        internal FlightReferenceBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            flightHintIndex = binaryReader.ReadInt16( );
            poitIndex = binaryReader.ReadInt16( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( flightHintIndex );
                binaryWriter.Write( poitIndex );
                return nextAddress;
            }
        }
    };
}