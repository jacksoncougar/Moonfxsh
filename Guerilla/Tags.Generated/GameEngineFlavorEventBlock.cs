// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GameEngineFlavorEventBlock : GameEngineFlavorEventBlockBase
    {
        public  GameEngineFlavorEventBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GameEngineFlavorEventBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 168, Alignment = 4)]
    public class GameEngineFlavorEventBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal Event _event;
        internal Audience audience;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal Moonfish.Tags.StringID displayString;
        internal RequiredField requiredField;
        internal ExcludedAudience excludedAudience;
        internal Moonfish.Tags.StringID primaryString;
        internal int primaryStringDurationSeconds;
        internal Moonfish.Tags.StringID pluralDisplayString;
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
        
        public override int SerializedSize{get { return 168; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GameEngineFlavorEventBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
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
            extraSounds = new SoundResponseExtraSoundsStructBlock(binaryReader);
            invalidName_4 = binaryReader.ReadBytes(4);
            invalidName_5 = binaryReader.ReadBytes(16);
            soundPermutations = Guerilla.ReadBlockArray<SoundResponseDefinitionBlock>(binaryReader);
        }
        public  GameEngineFlavorEventBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
            DoubleKill = 0,
            TripleKill = 1,
            Killtacular = 2,
            KillingSpree = 3,
            RunningRiot = 4,
            WellPlacedKill = 5,
            BrokeKillingSpree = 6,
            KillFrenzy = 7,
            Killtrocity = 8,
            Killimajaro = 9,
            InvalidName15InARow = 10,
            InvalidName20InARow = 11,
            InvalidName25InARow = 12,
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
