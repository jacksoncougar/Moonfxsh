using System.IO;

namespace Moonfish.Tags
{
    internal interface IWriteable
    {
        void Write( BinaryWriter binaryWriter );
    }
}