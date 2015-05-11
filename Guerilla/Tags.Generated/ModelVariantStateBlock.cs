// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ModelVariantStateBlock : ModelVariantStateBlockBase
    {
        public ModelVariantStateBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ModelVariantStateBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent permutationName;
        internal byte[] invalidName_;
        internal PropertyFlags propertyFlags;
        internal State state;

        /// <summary>
        /// played while the model is in this state
        /// </summary>
        [TagReference("effe")] internal Moonfish.Tags.TagReference loopingEffect;

        internal Moonfish.Tags.StringIdent loopingEffectMarkerName;
        internal float initialProbability;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ModelVariantStateBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            permutationName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(1);
            propertyFlags = (PropertyFlags) binaryReader.ReadByte();
            state = (State) binaryReader.ReadInt16();
            loopingEffect = binaryReader.ReadTagReference();
            loopingEffectMarkerName = binaryReader.ReadStringID();
            initialProbability = binaryReader.ReadSingle();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(permutationName);
                binaryWriter.Write(invalidName_, 0, 1);
                binaryWriter.Write((Byte) propertyFlags);
                binaryWriter.Write((Int16) state);
                binaryWriter.Write(loopingEffect);
                binaryWriter.Write(loopingEffectMarkerName);
                binaryWriter.Write(initialProbability);
                return nextAddress;
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