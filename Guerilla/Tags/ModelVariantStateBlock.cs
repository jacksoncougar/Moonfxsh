using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [LayoutAttribute(Size = 24)]
    public  partial class ModelVariantStateBlock : ModelVariantStateBlockBase
    {
        public  ModelVariantStateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class ModelVariantStateBlockBase
    {
        internal Moonfish.Tags.StringID permutationName;
        internal byte[] invalidName_;
        internal PropertyFlags propertyFlags;
        internal State state;
        /// <summary>
        /// played while the model is in this state
        /// </summary>
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference loopingEffect;
        internal Moonfish.Tags.StringID loopingEffectMarkerName;
        internal float initialProbability;
        internal  ModelVariantStateBlockBase(BinaryReader binaryReader)
        {
            this.permutationName = binaryReader.ReadStringID();
            this.invalidName_ = binaryReader.ReadBytes(1);
            this.propertyFlags = (PropertyFlags)binaryReader.ReadByte();
            this.state = (State)binaryReader.ReadInt16();
            this.loopingEffect = binaryReader.ReadTagReference();
            this.loopingEffectMarkerName = binaryReader.ReadStringID();
            this.initialProbability = binaryReader.ReadSingle();
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
        internal enum PropertyFlags : byte
        {
            Blurred = 1,
            HellaBlurred = 2,
            Shielded = 4,
        };
        internal enum State : short
        {
            Default = 0,
            MinorDamage = 1,
            MediumDamage = 2,
            MajorDamage = 3,
            Destroyed = 4,
        };
    };
}
