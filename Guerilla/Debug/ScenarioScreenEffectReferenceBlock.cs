// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioScreenEffectReferenceBlock : ScenarioScreenEffectReferenceBlockBase
    {
        public  ScenarioScreenEffectReferenceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class ScenarioScreenEffectReferenceBlockBase
    {
        internal byte[] invalidName_;
        [TagReference("egor")]
        internal Moonfish.Tags.TagReference screenEffect;
        internal Moonfish.Tags.StringID primaryInputInterpolator;
        internal Moonfish.Tags.StringID secondaryInputInterpolator;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal  ScenarioScreenEffectReferenceBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(16);
            screenEffect = binaryReader.ReadTagReference();
            primaryInputInterpolator = binaryReader.ReadStringID();
            secondaryInputInterpolator = binaryReader.ReadStringID();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(2);
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
                binaryWriter.Write(invalidName_, 0, 16);
                binaryWriter.Write(screenEffect);
                binaryWriter.Write(primaryInputInterpolator);
                binaryWriter.Write(secondaryInputInterpolator);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 2);
            }
        }
    };
}
