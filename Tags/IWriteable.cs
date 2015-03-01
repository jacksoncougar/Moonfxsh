using System.IO;

namespace Moonfish.Tags
{
    interface IWriteable
    {
        void Write( BinaryWriter binaryWriter );
    }
}
