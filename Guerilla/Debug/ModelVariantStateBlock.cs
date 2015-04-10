// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ModelVariantStateBlock : ModelVariantStateBlockBase
    {
        public  ModelVariantStateBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ModelVariantStateBlockBase(System.IO.BinaryReader binaryReader)
        {
            permutationName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(1);
            propertyFlags = (PropertyFlags)binaryReader.ReadByte();
            state = (State)binaryReader.ReadInt16();
            loopingEffect = binaryReader.ReadTagReference();
            loopingEffectMarkerName = binaryReader.ReadStringID();
            initialProbability = binaryReader.ReadSingle();
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
                binaryWriter.Write(permutationName);
                binaryWriter.Write(invalidName_, 0, 1);
                binaryWriter.Write((Byte)propertyFlags);
                binaryWriter.Write((Int16)state);
                binaryWriter.Write(loopingEffect);
                binaryWriter.Write(loopingEffectMarkerName);
                binaryWriter.Write(initialProbability);
            }
        }
        [FlagsAttribute]
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
