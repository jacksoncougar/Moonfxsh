//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class VocalizationDefinitionsBlock5 : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent Vocalization;
        public Moonfish.Tags.StringIdent ParentVocalization;
        public short ParentIndex;
        public PriorityEnum Priority;
        public Flags VocalizationDefinitions5Flags;
        public GlanceBehaviorEnum GlanceBehavior;
        public GlanceRecipientBehaviorEnum GlanceRecipientBehavior;
        public PerceptionTypeEnum PerceptionType;
        public MaxCombatStatusEnum MaxCombatStatus;
        public AnimationImpulseEnum AnimationImpulse;
        public OverlapPriorityEnum OverlapPriority;
        public float SoundRepetitionDelay;
        public float AllowableQueueDelay;
        public float PreVocDelay;
        public float NotificationDelay;
        public float PostVocDelay;
        public float RepeatDelay;
        public float Weight;
        public float SpeakerFreezeTime;
        public float ListenerFreezeTime;
        public SpeakerEmotionEnum SpeakerEmotion;
        public ListenerEmotionEnum ListenerEmotion;
        public float PlayerSkipFraction;
        public float SkipFraction;
        public Moonfish.Tags.StringIdent SampleLine;
        public ResponseBlock[] Reponses = new ResponseBlock[0];
        public GNullBlock[] GNullBlock = new GNullBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 96;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.Vocalization = binaryReader.ReadStringID();
            this.ParentVocalization = binaryReader.ReadStringID();
            this.ParentIndex = binaryReader.ReadInt16();
            this.Priority = ((PriorityEnum)(binaryReader.ReadInt16()));
            this.VocalizationDefinitions5Flags = ((Flags)(binaryReader.ReadInt32()));
            this.GlanceBehavior = ((GlanceBehaviorEnum)(binaryReader.ReadInt16()));
            this.GlanceRecipientBehavior = ((GlanceRecipientBehaviorEnum)(binaryReader.ReadInt16()));
            this.PerceptionType = ((PerceptionTypeEnum)(binaryReader.ReadInt16()));
            this.MaxCombatStatus = ((MaxCombatStatusEnum)(binaryReader.ReadInt16()));
            this.AnimationImpulse = ((AnimationImpulseEnum)(binaryReader.ReadInt16()));
            this.OverlapPriority = ((OverlapPriorityEnum)(binaryReader.ReadInt16()));
            this.SoundRepetitionDelay = binaryReader.ReadSingle();
            this.AllowableQueueDelay = binaryReader.ReadSingle();
            this.PreVocDelay = binaryReader.ReadSingle();
            this.NotificationDelay = binaryReader.ReadSingle();
            this.PostVocDelay = binaryReader.ReadSingle();
            this.RepeatDelay = binaryReader.ReadSingle();
            this.Weight = binaryReader.ReadSingle();
            this.SpeakerFreezeTime = binaryReader.ReadSingle();
            this.ListenerFreezeTime = binaryReader.ReadSingle();
            this.SpeakerEmotion = ((SpeakerEmotionEnum)(binaryReader.ReadInt16()));
            this.ListenerEmotion = ((ListenerEmotionEnum)(binaryReader.ReadInt16()));
            this.PlayerSkipFraction = binaryReader.ReadSingle();
            this.SkipFraction = binaryReader.ReadSingle();
            this.SampleLine = binaryReader.ReadStringID();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(12));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(0));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Reponses = base.ReadBlockArrayData<ResponseBlock>(binaryReader, pointerQueue.Dequeue());
            this.GNullBlock = base.ReadBlockArrayData<GNullBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Reponses);
            queueableBinaryWriter.QueueWrite(this.GNullBlock);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Vocalization);
            queueableBinaryWriter.Write(this.ParentVocalization);
            queueableBinaryWriter.Write(this.ParentIndex);
            queueableBinaryWriter.Write(((short)(this.Priority)));
            queueableBinaryWriter.Write(((int)(this.VocalizationDefinitions5Flags)));
            queueableBinaryWriter.Write(((short)(this.GlanceBehavior)));
            queueableBinaryWriter.Write(((short)(this.GlanceRecipientBehavior)));
            queueableBinaryWriter.Write(((short)(this.PerceptionType)));
            queueableBinaryWriter.Write(((short)(this.MaxCombatStatus)));
            queueableBinaryWriter.Write(((short)(this.AnimationImpulse)));
            queueableBinaryWriter.Write(((short)(this.OverlapPriority)));
            queueableBinaryWriter.Write(this.SoundRepetitionDelay);
            queueableBinaryWriter.Write(this.AllowableQueueDelay);
            queueableBinaryWriter.Write(this.PreVocDelay);
            queueableBinaryWriter.Write(this.NotificationDelay);
            queueableBinaryWriter.Write(this.PostVocDelay);
            queueableBinaryWriter.Write(this.RepeatDelay);
            queueableBinaryWriter.Write(this.Weight);
            queueableBinaryWriter.Write(this.SpeakerFreezeTime);
            queueableBinaryWriter.Write(this.ListenerFreezeTime);
            queueableBinaryWriter.Write(((short)(this.SpeakerEmotion)));
            queueableBinaryWriter.Write(((short)(this.ListenerEmotion)));
            queueableBinaryWriter.Write(this.PlayerSkipFraction);
            queueableBinaryWriter.Write(this.SkipFraction);
            queueableBinaryWriter.Write(this.SampleLine);
            queueableBinaryWriter.WritePointer(this.Reponses);
            queueableBinaryWriter.WritePointer(this.GNullBlock);
        }
        public enum PriorityEnum : short
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
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            Immediate = 1,
            Interrupt = 2,
            CancelLowPriority = 4,
        }
        public enum GlanceBehaviorEnum : short
        {
            NONE = 0,
            GlanceSubjectShort = 1,
            GlanceSubjectLong = 2,
            GlanceCauseShort = 3,
            GlanceCauseLong = 4,
            GlanceFriendShort = 5,
            GlanceFriendLong = 6,
        }
        public enum GlanceRecipientBehaviorEnum : short
        {
            NONE = 0,
            GlanceSubjectShort = 1,
            GlanceSubjectLong = 2,
            GlanceCauseShort = 3,
            GlanceCauseLong = 4,
            GlanceFriendShort = 5,
            GlanceFriendLong = 6,
        }
        public enum PerceptionTypeEnum : short
        {
            None = 0,
            Speaker = 1,
            Listener = 2,
        }
        public enum MaxCombatStatusEnum : short
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
        }
        public enum AnimationImpulseEnum : short
        {
            None = 0,
            Shakefist = 1,
            Cheer = 2,
            Surprisefront = 3,
            Surpriseback = 4,
            Taunt = 5,
            Brace = 6,
            Point = 7,
            Hold = 8,
            Wave = 9,
            Advance = 10,
            Fallback = 11,
        }
        public enum OverlapPriorityEnum : short
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
        }
        public enum SpeakerEmotionEnum : short
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
        }
        public enum ListenerEmotionEnum : short
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
        }
    }
}
