// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioScreenEffectReferenceBlock : ScenarioScreenEffectReferenceBlockBase
    {
        public  ScenarioScreenEffectReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioScreenEffectReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class ScenarioScreenEffectReferenceBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        [TagReference("egor")]
        internal Moonfish.Tags.TagReference screenEffect;
        internal Moonfish.Tags.StringID primaryInputInterpolator;
        internal Moonfish.Tags.StringID secondaryInputInterpolator;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        
        public override int SerializedSize{get { return 36; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioScreenEffectReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(16);
            screenEffect = binaryReader.ReadTagReference();
            primaryInputInterpolator = binaryReader.ReadStringID();
            secondaryInputInterpolator = binaryReader.ReadStringID();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(2);
        }
        public  ScenarioScreenEffectReferenceBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(16);
            screenEffect = binaryReader.ReadTagReference();
            primaryInputInterpolator = binaryReader.ReadStringID();
            secondaryInputInterpolator = binaryReader.ReadStringID();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(2);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 16);
                binaryWriter.Write(screenEffect);
                binaryWriter.Write(primaryInputInterpolator);
                binaryWriter.Write(secondaryInputInterpolator);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 2);
                return nextAddress;
            }
        }
    };
}
