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
        public  ScenarioScreenEffectReferenceBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioScreenEffectReferenceBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(16);
            this.screenEffect = binaryReader.ReadTagReference();
            this.primaryInputInterpolator = binaryReader.ReadStringID();
            this.secondaryInputInterpolator = binaryReader.ReadStringID();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(2);
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
