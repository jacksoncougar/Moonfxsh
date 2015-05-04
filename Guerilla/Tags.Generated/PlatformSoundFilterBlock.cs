// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlatformSoundFilterBlock : PlatformSoundFilterBlockBase
    {
        public PlatformSoundFilterBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 72, Alignment = 4)]
    public class PlatformSoundFilterBlockBase : GuerillaBlock
    {
        internal FilterType filterType;
        internal int filterWidth07;
        internal SoundPlaybackParameterDefinitionBlock leftFilterFrequency;
        internal SoundPlaybackParameterDefinitionBlock leftFilterGain;
        internal SoundPlaybackParameterDefinitionBlock rightFilterFrequency;
        internal SoundPlaybackParameterDefinitionBlock rightFilterGain;
        public override int SerializedSize { get { return 72; } }
        public override int Alignment { get { return 4; } }
        public PlatformSoundFilterBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            filterType = (FilterType)binaryReader.ReadInt32();
            filterWidth07 = binaryReader.ReadInt32();
            leftFilterFrequency = new SoundPlaybackParameterDefinitionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(leftFilterFrequency.ReadFields(binaryReader)));
            leftFilterGain = new SoundPlaybackParameterDefinitionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(leftFilterGain.ReadFields(binaryReader)));
            rightFilterFrequency = new SoundPlaybackParameterDefinitionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(rightFilterFrequency.ReadFields(binaryReader)));
            rightFilterGain = new SoundPlaybackParameterDefinitionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(rightFilterGain.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            leftFilterFrequency.ReadPointers(binaryReader, blamPointers);
            leftFilterGain.ReadPointers(binaryReader, blamPointers);
            rightFilterFrequency.ReadPointers(binaryReader, blamPointers);
            rightFilterGain.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)filterType);
                binaryWriter.Write(filterWidth07);
                leftFilterFrequency.Write(binaryWriter);
                leftFilterGain.Write(binaryWriter);
                rightFilterFrequency.Write(binaryWriter);
                rightFilterGain.Write(binaryWriter);
                return nextAddress;
            }
        }
        internal enum FilterType : int
        {
            ParametricEQ = 0,
            DLS2 = 1,
            BothOnlyValidForMono = 2,
        };
    };
}
