using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GameEngineKingEventBlock : GameEngineKingEventBlockBase
    {
        public  GameEngineKingEventBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 168)]
    public class GameEngineKingEventBlockBase
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
        internal  GameEngineKingEventBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this._event = (Event)binaryReader.ReadInt16();
            this.audience = (Audience)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.displayString = binaryReader.ReadStringID();
            this.requiredField = (RequiredField)binaryReader.ReadInt16();
            this.excludedAudience = (ExcludedAudience)binaryReader.ReadInt16();
            this.primaryString = binaryReader.ReadStringID();
            this.primaryStringDurationSeconds = binaryReader.ReadInt32();
            this.pluralDisplayString = binaryReader.ReadStringID();
            this.invalidName_2 = binaryReader.ReadBytes(28);
            this.soundDelayAnnouncerOnly = binaryReader.ReadSingle();
            this.soundFlags = (SoundFlags)binaryReader.ReadInt16();
            this.invalidName_3 = binaryReader.ReadBytes(2);
            this.sound = binaryReader.ReadTagReference();
            this.extraSounds = new SoundResponseExtraSoundsStructBlock(binaryReader);
            this.invalidName_4 = binaryReader.ReadBytes(4);
            this.invalidName_5 = binaryReader.ReadBytes(16);
            this.soundPermutations = ReadSoundResponseDefinitionBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual SoundResponseDefinitionBlock[] ReadSoundResponseDefinitionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundResponseDefinitionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundResponseDefinitionBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundResponseDefinitionBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            QuantityMessage = 1,
        };
        internal enum Event : short
        
        {
            GameStart = 0,
            HillControlled = 1,
            HillContested = 2,
            HillTick = 3,
            HillMove = 4,
            HillControlledTeam = 5,
            HillContestedTeam = 6,
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
