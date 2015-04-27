// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class VocalizationDefinitionsBlock4 : VocalizationDefinitionsBlock4Base
    {
        public  VocalizationDefinitionsBlock4(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 96, Alignment = 4)]
    public class VocalizationDefinitionsBlock4Base : GuerillaBlock
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
        internal VocalizationDefinitionsBlock5[] children;
        
        public override int SerializedSize{get { return 96; }}
        
        internal  VocalizationDefinitionsBlock4Base(BinaryReader binaryReader): base(binaryReader)
        {
            vocalization = binaryReader.ReadStringID();
            parentVocalization = binaryReader.ReadStringID();
            parentIndex = binaryReader.ReadInt16();
            priority = (Priority)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt32();
            glanceBehavior = (GlanceBehaviorHowDoesTheSpeakerOfThisVocalizationDirectHisGaze)binaryReader.ReadInt16();
            glanceRecipientBehavior = (GlanceRecipientBehaviorHowDoesSomeoneWhoHearsMeBehave)binaryReader.ReadInt16();
            perceptionType = (PerceptionType)binaryReader.ReadInt16();
            maxCombatStatus = (MaxCombatStatus)binaryReader.ReadInt16();
            animationImpulse = (AnimationImpulse)binaryReader.ReadInt16();
            overlapPriority = (OverlapPriority)binaryReader.ReadInt16();
            soundRepetitionDelayMinutes = binaryReader.ReadSingle();
            allowableQueueDelaySeconds = binaryReader.ReadSingle();
            preVocDelaySeconds = binaryReader.ReadSingle();
            notificationDelaySeconds = binaryReader.ReadSingle();
            postVocDelaySeconds = binaryReader.ReadSingle();
            repeatDelaySeconds = binaryReader.ReadSingle();
            weight01 = binaryReader.ReadSingle();
            speakerFreezeTime = binaryReader.ReadSingle();
            listenerFreezeTime = binaryReader.ReadSingle();
            speakerEmotion = (SpeakerEmotion)binaryReader.ReadInt16();
            listenerEmotion = (ListenerEmotion)binaryReader.ReadInt16();
            playerSkipFraction = binaryReader.ReadSingle();
            skipFraction = binaryReader.ReadSingle();
            sampleLine = binaryReader.ReadStringID();
            reponses = Guerilla.ReadBlockArray<ResponseBlock>(binaryReader);
            children = Guerilla.ReadBlockArray<VocalizationDefinitionsBlock5>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(vocalization);
                binaryWriter.Write(parentVocalization);
                binaryWriter.Write(parentIndex);
                binaryWriter.Write((Int16)priority);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write((Int16)glanceBehavior);
                binaryWriter.Write((Int16)glanceRecipientBehavior);
                binaryWriter.Write((Int16)perceptionType);
                binaryWriter.Write((Int16)maxCombatStatus);
                binaryWriter.Write((Int16)animationImpulse);
                binaryWriter.Write((Int16)overlapPriority);
                binaryWriter.Write(soundRepetitionDelayMinutes);
                binaryWriter.Write(allowableQueueDelaySeconds);
                binaryWriter.Write(preVocDelaySeconds);
                binaryWriter.Write(notificationDelaySeconds);
                binaryWriter.Write(postVocDelaySeconds);
                binaryWriter.Write(repeatDelaySeconds);
                binaryWriter.Write(weight01);
                binaryWriter.Write(speakerFreezeTime);
                binaryWriter.Write(listenerFreezeTime);
                binaryWriter.Write((Int16)speakerEmotion);
                binaryWriter.Write((Int16)listenerEmotion);
                binaryWriter.Write(playerSkipFraction);
                binaryWriter.Write(skipFraction);
                binaryWriter.Write(sampleLine);
                nextAddress = Guerilla.WriteBlockArray<ResponseBlock>(binaryWriter, reponses, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<VocalizationDefinitionsBlock5>(binaryWriter, children, nextAddress);
                return nextAddress;
            }
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
