// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalSubpartsBlock : GlobalSubpartsBlockBase
    {
        public  GlobalSubpartsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class GlobalSubpartsBlockBase  : IGuerilla
    {
        internal short indicesStartIndex;
        internal short indicesLength;
        internal short visibilityBoundsIndex;
        internal short partIndex;
        internal  GlobalSubpartsBlockBase(BinaryReader binaryReader)
        {
            indicesStartIndex = binaryReader.ReadInt16();
            indicesLength = binaryReader.ReadInt16();
            visibilityBoundsIndex = binaryReader.ReadInt16();
            partIndex = binaryReader.ReadInt16();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(indicesStartIndex);
                binaryWriter.Write(indicesLength);
                binaryWriter.Write(visibilityBoundsIndex);
                binaryWriter.Write(partIndex);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
