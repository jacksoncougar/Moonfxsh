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
        public  SyntaxDatumBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  SyntaxDatumBlockBase(BinaryReader binaryReader)
        {
            this.datumHeader = binaryReader.ReadInt16();
            this.scriptIndexFunctionIndexConstantTypeUnion = binaryReader.ReadInt16();
            this.type = binaryReader.ReadInt16();
            this.flags = binaryReader.ReadInt16();
            this.nextNodeIndex = binaryReader.ReadInt32();
            this.data = binaryReader.ReadInt32();
            this.sourceOffset = binaryReader.ReadInt32();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
