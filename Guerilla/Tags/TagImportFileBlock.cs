using Moonfish.Tags.BlamExtension;
using System.IO;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Tags
{
    public partial class TagImportFileBlock : TagImportFileBlockBase
    {
        public TagImportFileBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [Layout( Size = 528 )]
    public class TagImportFileBlockBase
    {
        internal String256 path;
        internal String32 modificationDate;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal int checksumCrc32;
        internal int sizeBytes;
        internal byte[] zippedData;
        internal byte[] invalidName_1;
        internal TagImportFileBlockBase( BinaryReader binaryReader )
        {
            this.path = binaryReader.ReadString256();
            this.modificationDate = binaryReader.ReadString32();
            this.invalidName_ = binaryReader.ReadBytes( 8 );
            this.invalidName_0 = binaryReader.ReadBytes( 88 );
            this.checksumCrc32 = binaryReader.ReadInt32();
            this.sizeBytes = binaryReader.ReadInt32();
            this.zippedData = ReadData( binaryReader );
            this.invalidName_1 = binaryReader.ReadBytes( 128 );
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
    };
}
