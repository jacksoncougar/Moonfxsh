// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SyntaxDatumBlock : SyntaxDatumBlockBase
    {
        public  SyntaxDatumBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class SyntaxDatumBlockBase
    {
        internal short datumHeader;
        internal short scriptIndexFunctionIndexConstantTypeUnion;
        internal short type;
        internal short flags;
        internal int nextNodeIndex;
        internal int data;
        internal int sourceOffset;
        internal  SyntaxDatumBlockBase(System.IO.BinaryReader binaryReader)
        {
            datumHeader = binaryReader.ReadInt16();
            scriptIndexFunctionIndexConstantTypeUnion = binaryReader.ReadInt16();
            type = binaryReader.ReadInt16();
            flags = binaryReader.ReadInt16();
            nextNodeIndex = binaryReader.ReadInt32();
            data = binaryReader.ReadInt32();
            sourceOffset = binaryReader.ReadInt32();
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
                binaryWriter.Write(datumHeader);
                binaryWriter.Write(scriptIndexFunctionIndexConstantTypeUnion);
                binaryWriter.Write(type);
                binaryWriter.Write(flags);
                binaryWriter.Write(nextNodeIndex);
                binaryWriter.Write(data);
                binaryWriter.Write(sourceOffset);
            }
        }
    };
}
