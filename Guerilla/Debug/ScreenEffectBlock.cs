// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("egor")]
    public  partial class ScreenEffectBlock : ScreenEffectBlockBase
    {
        public  ScreenEffectBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 144)]
    public class ScreenEffectBlockBase
    {
        internal byte[] invalidName_;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shader;
        internal byte[] invalidName_0;
        internal RasterizerScreenEffectPassReferenceBlock[] passReferences;
        internal  ScreenEffectBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(64);
            shader = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadBytes(64);
            ReadRasterizerScreenEffectPassReferenceBlockArray(binaryReader);
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
        internal  virtual RasterizerScreenEffectPassReferenceBlock[] ReadRasterizerScreenEffectPassReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RasterizerScreenEffectPassReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RasterizerScreenEffectPassReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RasterizerScreenEffectPassReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRasterizerScreenEffectPassReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 64);
                binaryWriter.Write(shader);
                binaryWriter.Write(invalidName_0, 0, 64);
                WriteRasterizerScreenEffectPassReferenceBlockArray(binaryWriter);
            }
        }
    };
}
