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
        public  ScreenEffectBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ScreenEffectBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(64);
            this.shader = binaryReader.ReadTagReference();
            this.invalidName_0 = binaryReader.ReadBytes(64);
            this.passReferences = ReadRasterizerScreenEffectPassReferenceBlockArray(binaryReader);
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
        internal  virtual RasterizerScreenEffectPassReferenceBlock[] ReadRasterizerScreenEffectPassReferenceBlockArray(BinaryReader binaryReader)
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
    };
}
