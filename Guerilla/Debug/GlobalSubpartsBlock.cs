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
        public  GlobalSubpartsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class GlobalSubpartsBlockBase
    {
        internal short indicesStartIndex;
        internal short indicesLength;
        internal short visibilityBoundsIndex;
        internal short partIndex;
        internal  GlobalSubpartsBlockBase(System.IO.BinaryReader binaryReader)
        {
            indicesStartIndex = binaryReader.ReadInt16();
            indicesLength = binaryReader.ReadInt16();
            visibilityBoundsIndex = binaryReader.ReadInt16();
            partIndex = binaryReader.ReadInt16();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(indicesStartIndex);
                binaryWriter.Write(indicesLength);
                binaryWriter.Write(visibilityBoundsIndex);
                binaryWriter.Write(partIndex);
            }
        }
    };
}
