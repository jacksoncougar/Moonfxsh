using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class VocalizationDefinitionsBlock0 : VocalizationDefinitionsBlock0Base
    {
        public  VocalizationDefinitionsBlock0(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 96)]
    public class VocalizationDefinitionsBlock0Base
    {
        internal Moonfish.Tags.StringID vocalization;
        internal Moonfish.Tags.StringID parentVocalization;
        internal short parentIndex;
        internal Priority priority;
        internal Flags flags;
        /// <summary>
        /// how does the speaker of this vocalization direct his gaze?
        /// </summary>
        internal GlanceBehaviorHowDoesTheSpeakerOfThisVocalizationDirectHisGaze glanceBehavior;
        /// <summary>
        /// how does someone who hears me behave?
        /// </summary>
        internal GlanceRecipientBehaviorHowDoesSomeoneWhoHearsMeBehave glanceRecipientBehavior;
        internal PerceptionType perceptionType;
        internal MaxCombatStatus maxCombatStatus;
        internal AnimationImpulse animationImpulse;
        internal OverlapPriority overlapPriority;
        /// <summary>
        /// Minimum delay time between playing the same permutation
        /// </summary>
        internal float soundRepetitionDelayMinutes;
        /// <summary>
        /// How long to wait to actually start the vocalization
        /// </summary>
        internal float allowableQueueDelaySeconds;
        /// <summary>
        /// How long to wait to actually start the vocalization
        /// </summary>
        internal float preVocDelaySeconds;
        /// <summary>
        /// How long into the vocalization the AI should be notified
        /// </summary>
        internal float notificationDelaySeconds;
        /// <summary>
        /// How long speech is suppressed in the speaking unit after vocalizing
        /// </summary>
        internal float postVocDelaySeconds;
        /// <summary>
        /// How long before the same vocalization can be repeated
        /// </summary>
        internal float repeatDelaySeconds;
        /// <summary>
        /// Inherent weight of this vocalization
        /// </summary>
        internal float weight01;
        /// <summary>
        /// speaker won't move for the given amount of time
        /// </summary>
        internal float speakerFreezeTime;
        /// <summary>
        /// listener won't move for the given amount of time (from start of vocalization)
        /// </summary>
        internal float listenerFreezeTime;
        internal SpeakerEmotion speakerEmotion;
        internal ListenerEmotion listenerEmotion;
        internal float playerSkipFraction;
        internal float skipFraction;
        internal Moonfish.Tags.StringID sampleLine;
        internal ResponseBlock[] reponses;
        internal VocalizationDefinitionsBlock1[] children;
        internal  VocalizationDefinitionsBlock0Base(BinaryReader binaryReader)
        {
            this.vocalization = binaryReader.ReadStringID();
            this.parentVocalization = binaryReader.ReadStringID();
            this.parentIndex = binaryReader.ReadInt16();
            this.priority = (Priority)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.glanceBehavior = (GlanceBehaviorHowDoesTheSpeakerOfThisVocalizationDirectHisGaze)binaryReader.ReadInt16();
            this.glanceRecipientBehavior = (GlanceRecipientBehaviorHowDoesSomeoneWhoHearsMeBehave)binaryReader.ReadInt16();
            this.perceptionType = (PerceptionType)binaryReader.ReadInt16();
            this.maxCombatStatus = (MaxCombatStatus)binaryReader.ReadInt16();
            this.animationImpulse = (AnimationImpulse)binaryReader.ReadInt16();
            this.overlapPriority = (OverlapPriority)binaryReader.ReadInt16();
            this.soundRepetitionDelayMinutes = binaryReader.ReadSingle();
            this.allowableQueueDelaySeconds = binaryReader.ReadSingle();
            this.preVocDelaySeconds = binaryReader.ReadSingle();
            this.notificationDelaySeconds = binaryReader.ReadSingle();
            this.postVocDelaySeconds = binaryReader.ReadSingle();
            this.repeatDelaySeconds = binaryReader.ReadSingle();
            this.weight01 = binaryReader.ReadSingle();
            this.speakerFreezeTime = binaryReader.ReadSingle();
            this.listenerFreezeTime = binaryReader.ReadSingle();
            this.speakerEmotion = (SpeakerEmotion)binaryReader.ReadInt16();
            this.listenerEmotion = (ListenerEmotion)binaryReader.ReadInt16();
            this.playerSkipFraction = binaryReader.ReadSingle();
            this.skipFraction = binaryReader.ReadSingle();
            this.sampleLine = binaryReader.ReadStringID();
            this.reponses = ReadResponseBlockArray(binaryReader);
            this.children = ReadVocalizationDefinitionsBlock1Array(binaryReader);
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
        internal  virtual ResponseBlock[] ReadResponseBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ResponseBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ResponseBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ResponseBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual VocalizationDefinitionsBlock1[] ReadVocalizationDefinitionsBlock1Array(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(VocalizationDefinitionsBlock1));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new VocalizationDefinitionsBlock1[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new VocalizationDefinitionsBlock1(binaryReader);
                }
            }
            return array;
        }
        internal enum Priority : short
        
        {
            None = 0,
            Recall = 1,
            Idle = 2,
            Comment = 3,
            IdleResponse = 4,
            Postcombat = 5,
            Combat = 6,
            Status = 7,
            Respond = 8,
            Warn = 9,
            Act = 10,
            React = 11,
            Involuntary = 12,
            Scream = 13,
            Scripted = 14,
            Death = 15,
        };
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            Immediate = 1,
            Interrupt = 2,
            CancelLowPriority = 4,
        };
        internal enum GlanceBehaviorHowDoesTheSpeakerOfThisVocalizationDirectHisGaze : short
        
        {
            NONE = 0,
            GlanceSubjectShort = 1,
            GlanceSubjectLong = 2,
            GlanceCauseShort = 3,
            GlanceCauseLong = 4,
            GlanceFriendShort = 5,
            GlanceFriendLong = 6,
        };
        internal enum GlanceRecipientBehaviorHowDoesSomeoneWhoHearsMeBehave : short
        
        {
            NONE = 0,
            GlanceSubjectShort = 1,
            GlanceSubjectLong = 2,
            GlanceCauseShort = 3,
            GlanceCauseLong = 4,
            GlanceFriendShort = 5,
            GlanceFriendLong = 6,
        };
        internal enum PerceptionType : short
        
        {
            None = 0,
            Speaker = 1,
            Listener = 2,
        };
        internal enum MaxCombatStatus : short
        
        {
            Asleep = 0,
            Idle = 1,
            Alert = 2,
            Active = 3,
            Uninspected = 4,
            Definite = 5,
            Certain = 6,
            Visible = 7,
            ClearLos = 8,
            Dangerous = 9,
        };
        internal enum AnimationImpulse : short
        
        {
            None = 0,
            Shakefist = 1,
            Cheer = 2,
            SurpriseFront = 3,
            SurpriseBack = 4,
            Taunt = 5,
            Brace = 6,
            Point = 7,
            Hold = 8,
            Wave = 9,
            Advance = 10,
            Fallback = 11,
        };
        internal enum OverlapPriority : short
        
        {
            None = 0,
            Recall = 1,
            Idle = 2,
            Comment = 3,
            IdleResponse = 4,
            Postcombat = 5,
            Combat = 6,
            Status = 7,
            Respond = 8,
            Warn = 9,
            Act = 10,
            React = 11,
            Involuntary = 12,
            Scream = 13,
            Scripted = 14,
            Death = 15,
        };
        internal enum SpeakerEmotion : short
        
        {
            None = 0,
            Asleep = 1,
            Amorous = 2,
            Happy = 3,
            Inquisitive = 4,
            Repulsed = 5,
            Disappointed = 6,
            Shocked = 7,
            Scared = 8,
            Arrogant = 9,
            Annoyed = 10,
            Angry = 11,
            Pensive = 12,
            Pain = 13,
        };
        internal enum ListenerEmotion : short
        
        {
            None = 0,
            Asleep = 1,
            Amorous = 2,
            Happy = 3,
            Inquisitive = 4,
            Repulsed = 5,
            Disappointed = 6,
            Shocked = 7,
            Scared = 8,
            Arrogant = 9,
            Annoyed = 10,
            Angry = 11,
            Pensive = 12,
            Pain = 13,
        };
    };
}
