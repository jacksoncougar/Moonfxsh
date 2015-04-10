using Moonfish.Tags.BlamExtension;
using System;
using System.IO;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Tags
{
    public partial class UserHintClimbBlock : UserHintClimbBlockBase
    {
        public UserHintClimbBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [Layout( Size = 4 )]
    public class UserHintClimbBlockBase
    {
        internal Flags flags;
        internal ShortBlockIndex1 geometryIndex;
        internal UserHintClimbBlockBase( BinaryReader binaryReader )
        {
            this.flags = ( Flags )binaryReader.ReadInt16();
            this.geometryIndex = binaryReader.ReadShortBlockIndex1();
        }
        internal virtual byte[] ReadData( BinaryReader binaryReader )
        {
            var blamPointer = binaryReader.ReadBlamPointer( 1 );
            var data = new byte[ blamPointer.Count ];
            if ( blamPointer.Count > 0 )
            {
                using ( binaryReader.BaseStream.Pin() )
                {
                    binaryReader.BaseStream.Position = blamPointer[ 0 ];
                    data = binaryReader.ReadBytes( blamPointer.Count );
                }
            }
            return data;
        }
        [Flags]
        internal enum Flags : short
        {
            Bidirectional = 1,
            Closed = 2,
        };
    };
}
