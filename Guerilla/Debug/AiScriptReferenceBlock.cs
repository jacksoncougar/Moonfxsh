// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AiScriptReferenceBlock : AiScriptReferenceBlockBase
    {
        public  AiScriptReferenceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class AiScriptReferenceBlockBase
    {
        internal Moonfish.Tags.String32 scriptName;
        internal byte[] invalidName_;
        internal  AiScriptReferenceBlockBase(System.IO.BinaryReader binaryReader)
        {
            scriptName = binaryReader.ReadString32();
            invalidName_ = binaryReader.ReadBytes(8);
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
                binaryWriter.Write(scriptName);
                binaryWriter.Write(invalidName_, 0, 8);
            }
        }
    };
}
