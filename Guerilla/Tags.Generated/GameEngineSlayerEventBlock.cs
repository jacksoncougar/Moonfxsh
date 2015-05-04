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
    public partial class GameEngineSlayerEventBlock : GameEngineSlayerEventBlockBase
    {
        public GameEngineSlayerEventBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 168, Alignment = 4)]
    public class GameEngineSlayerEventBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal Event _event;
        internal Audience audience;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal Moonfish.Tags.StringIdent displayString;
        internal RequiredField requiredField;
        internal ExcludedAudience excludedAudience;
        internal Moonfish.Tags.StringIdent primaryString;
        internal int primaryStringDurationSeconds;
        internal Moonfish.Tags.StringIdent pluralDisplayString;
        internal byte[] invalidName_2;
        internal float soundDelayAnnouncerOnly;
        internal SoundFlags soundFlags;
        internal byte[] invalidName_3;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference sound;
        internal SoundResponseExtraSoundsStructBlock extraSounds;
        internal byte[] invalidName_4;
        internal byte[] invalidName_5;
        internal SoundResponseDefinitionBlock[] soundPermutations;
        public override int SerializedSize { get { return 168; } }
        public override int Alignment { get { return 4; } }
        public GameEngineSlayerEventBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            _event = (Event)binaryReader.ReadInt16();
            audience = (Audience)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(2);
            displayString = binaryReader.ReadStringID();
            requiredField = (RequiredField)binaryReader.ReadInt16();
            excludedAudience = (ExcludedAudience)binaryReader.ReadInt16();
            primaryString = binaryReader.ReadStringID();
            primaryStringDurationSeconds = binaryReader.ReadInt32();
            pluralDisplayString = binaryReader.ReadStringID();
            invalidName_2 = binaryReader.ReadBytes(28);
            soundDelayAnnouncerOnly = binaryReader.ReadSingle();
            soundFlags = (SoundFlags)binaryReader.ReadInt16();
            invalidName_3 = binaryReader.ReadBytes(2);
            sound = binaryReader.ReadTagReference();
            extraSounds = new SoundResponseExtraSoundsStructBlock();
            blamPointers.Concat(extraSounds.ReadFields(binaryReader));
            invalidName_4 = binaryReader.ReadBytes(4);
            invalidName_5 = binaryReader.ReadBytes(16);
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundResponseDefinitionBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
            invalidName_2[0].ReadPointers(binaryReader, blamPointers);
            invalidName_2[1].ReadPointers(binaryReader, blamPointers);
            invalidName_2[2].ReadPointers(binaryReader, blamPointers);
            invalidName_2[3].ReadPointers(binaryReader, blamPointers);
            invalidName_2[4].ReadPointers(binaryReader, blamPointers);
            invalidName_2[5].ReadPointers(binaryReader, blamPointers);
            invalidName_2[6].ReadPointers(binaryReader, blamPointers);
            invalidName_2[7].ReadPointers(binaryReader, blamPointers);
            invalidName_2[8].ReadPointers(binaryReader, blamPointers);
            invalidName_2[9].ReadPointers(binaryReader, blamPointers);
            invalidName_2[10].ReadPointers(binaryReader, blamPointers);
            invalidName_2[11].ReadPointers(binaryReader, blamPointers);
            invalidName_2[12].ReadPointers(binaryReader, blamPointers);
            invalidName_2[13].ReadPointers(binaryReader, blamPointers);
            invalidName_2[14].ReadPointers(binaryReader, blamPointers);
            invalidName_2[15].ReadPointers(binaryReader, blamPointers);
            invalidName_2[16].ReadPointers(binaryReader, blamPointers);
            invalidName_2[17].ReadPointers(binaryReader, blamPointers);
            invalidName_2[18].ReadPointers(binaryReader, blamPointers);
            invalidName_2[19].ReadPointers(binaryReader, blamPointers);
            invalidName_2[20].ReadPointers(binaryReader, blamPointers);
            invalidName_2[21].ReadPointers(binaryReader, blamPointers);
            invalidName_2[22].ReadPointers(binaryReader, blamPointers);
            invalidName_2[23].ReadPointers(binaryReader, blamPointers);
            invalidName_2[24].ReadPointers(binaryReader, blamPointers);
            invalidName_2[25].ReadPointers(binaryReader, blamPointers);
            invalidName_2[26].ReadPointers(binaryReader, blamPointers);
            invalidName_2[27].ReadPointers(binaryReader, blamPointers);
            invalidName_3[0].ReadPointers(binaryReader, blamPointers);
            invalidName_3[1].ReadPointers(binaryReader, blamPointers);
            extraSounds.ReadPointers(binaryReader, blamPointers);
            invalidName_4[0].ReadPointers(binaryReader, blamPointers);
            invalidName_4[1].ReadPointers(binaryReader, blamPointers);
            invalidName_4[2].ReadPointers(binaryReader, blamPointers);
            invalidName_4[3].ReadPointers(binaryReader, blamPointers);
            invalidName_5[0].ReadPointers(binaryReader, blamPointers);
            invalidName_5[1].ReadPointers(binaryReader, blamPointers);
            invalidName_5[2].ReadPointers(binaryReader, blamPointers);
            invalidName_5[3].ReadPointers(binaryReader, blamPointers);
            invalidName_5[4].ReadPointers(binaryReader, blamPointers);
            invalidName_5[5].ReadPointers(binaryReader, blamPointers);
            invalidName_5[6].ReadPointers(binaryReader, blamPointers);
            invalidName_5[7].ReadPointers(binaryReader, blamPointers);
            invalidName_5[8].ReadPointers(binaryReader, blamPointers);
            invalidName_5[9].ReadPointers(binaryReader, blamPointers);
            invalidName_5[10].ReadPointers(binaryReader, blamPointers);
            invalidName_5[11].ReadPointers(binaryReader, blamPointers);
            invalidName_5[12].ReadPointers(binaryReader, blamPointers);
            invalidName_5[13].ReadPointers(binaryReader, blamPointers);
            invalidName_5[14].ReadPointers(binaryReader, blamPointers);
            invalidName_5[15].ReadPointers(binaryReader, blamPointers);
            soundPermutations = ReadBlockArrayData<SoundResponseDefinitionBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)_event);
                binaryWriter.Write((Int16)audience);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(displayString);
                binaryWriter.Write((Int16)requiredField);
                binaryWriter.Write((Int16)excludedAudience);
                binaryWriter.Write(primaryString);
                binaryWriter.Write(primaryStringDurationSeconds);
                binaryWriter.Write(pluralDisplayString);
                binaryWriter.Write(invalidName_2, 0, 28);
                binaryWriter.Write(soundDelayAnnouncerOnly);
                binaryWriter.Write((Int16)soundFlags);
                binaryWriter.Write(invalidName_3, 0, 2);
                binaryWriter.Write(sound);
                extraSounds.Write(binaryWriter);
                binaryWriter.Write(invalidName_4, 0, 4);
                binaryWriter.Write(invalidName_5, 0, 16);
                nextAddress = Guerilla.WriteBlockArray<SoundResponseDefinitionBlock>(binaryWriter, soundPermutations, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            QuantityMessage = 1,
        };
        internal enum Event : short
        {
            GameStart = 0,
            NewTarget = 1,
        };
        internal enum Audience : short
        {
            CausePlayer = 0,
            CauseTeam = 1,
            EffectPlayer = 2,
            EffectTeam = 3,
            All = 4,
        };
        internal enum RequiredField : short
        {
            NONE = 0,
            CausePlayer = 1,
            CauseTeam = 2,
            EffectPlayer = 3,
            EffectTeam = 4,
        };
        internal enum ExcludedAudience : short
        {
            NONE = 0,
            CausePlayer = 1,
            CauseTeam = 2,
            EffectPlayer = 3,
            EffectTeam = 4,
        };
        [FlagsAttribute]
        internal enum SoundFlags : short
        {
            AnnouncerSound = 1,
        };
    };
}
