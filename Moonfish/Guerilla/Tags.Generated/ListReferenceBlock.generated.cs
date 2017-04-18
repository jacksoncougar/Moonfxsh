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
    
    public partial class ListReferenceBlock : GuerillaBlock, IWriteQueueable
    {
        public Flags ListReferenceFlags;
        public SkinIndexEnum SkinIndex;
        public short NumVisibleItems;
        public Moonfish.Tags.Point BottomLeft;
        public AnimationIndexEnum AnimationIndex;
        public short IntroAnimationDelayMilliseconds;
        public STextValuePairReferenceBlockUNUSED[] UNUSED = new STextValuePairReferenceBlockUNUSED[0];
        public override int SerializedSize
        {
            get
            {
                return 24;
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
            this.ListReferenceFlags = ((Flags)(binaryReader.ReadInt32()));
            this.SkinIndex = ((SkinIndexEnum)(binaryReader.ReadInt16()));
            this.NumVisibleItems = binaryReader.ReadInt16();
            this.BottomLeft = binaryReader.ReadPoint();
            this.AnimationIndex = ((AnimationIndexEnum)(binaryReader.ReadInt16()));
            this.IntroAnimationDelayMilliseconds = binaryReader.ReadInt16();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(20));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.UNUSED = base.ReadBlockArrayData<STextValuePairReferenceBlockUNUSED>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.QueueWrite(this.UNUSED);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(((int)(this.ListReferenceFlags)));
            queueableBlamBinaryWriter.Write(((short)(this.SkinIndex)));
            queueableBlamBinaryWriter.Write(this.NumVisibleItems);
            queueableBlamBinaryWriter.Write(this.BottomLeft);
            queueableBlamBinaryWriter.Write(((short)(this.AnimationIndex)));
            queueableBlamBinaryWriter.Write(this.IntroAnimationDelayMilliseconds);
            queueableBlamBinaryWriter.WritePointer(this.UNUSED);
        }
        /// <summary>
        /// If the pane contains a list, define it here
        /// </summary>
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            ListWraps = 1,
            Interactive = 2,
        }
        public enum SkinIndexEnum : short
        {
            Default = 0,
            SquadLobbyPlayerList = 1,
            SettingsList = 2,
            PlaylistEntryList = 3,
            Variants = 4,
            GameBrowser = 5,
            OnlinePlayerMenu = 6,
            GameSetupMenu = 7,
            PlaylistContentsDisplay = 8,
            PlayerProfilePicker = 9,
            MpMapSelection = 10,
            MainMenuList = 11,
            ColorPicker = 12,
            ProfilePicker = 13,
            YMenuRecentList = 14,
            PcrTeamStats = 15,
            PcrPlayerStats = 16,
            PcrKillStats = 17,
            PcrPvpStats = 18,
            PcrMedalStats = 19,
            MatchmakingProgress = 20,
            Default5 = 21,
            Default6 = 22,
            AdvancedSettingsList = 23,
            LiveGameBrowser = 24,
            DefaultWide = 25,
            Unused26 = 26,
            Unused27 = 27,
            Unused28 = 28,
            Unused29 = 29,
            Unused30 = 30,
            Unused31 = 31,
        }
        public enum AnimationIndexEnum : short
        {
            NONE = 0,
            _00 = 1,
            _01 = 2,
            _02 = 3,
            _03 = 4,
            _04 = 5,
            _05 = 6,
            _06 = 7,
            _07 = 8,
            _08 = 9,
            _09 = 10,
            _10 = 11,
            _11 = 12,
            _12 = 13,
            _13 = 14,
            _14 = 15,
            _15 = 16,
            _16 = 17,
            _17 = 18,
            _18 = 19,
            _19 = 20,
            _20 = 21,
            _21 = 22,
            _22 = 23,
            _23 = 24,
            _24 = 25,
            _25 = 26,
            _26 = 27,
            _27 = 28,
            _28 = 29,
            _29 = 30,
            _30 = 31,
            _31 = 32,
            _32 = 33,
            _33 = 34,
            _34 = 35,
            _35 = 36,
            _36 = 37,
            _37 = 38,
            _38 = 39,
            _39 = 40,
            _40 = 41,
            _41 = 42,
            _42 = 43,
            _43 = 44,
            _44 = 45,
            _45 = 46,
            _46 = 47,
            _47 = 48,
            _48 = 49,
            _49 = 50,
            _50 = 51,
            _51 = 52,
            _52 = 53,
            _53 = 54,
            _54 = 55,
            _55 = 56,
            _56 = 57,
            _57 = 58,
            _58 = 59,
            _59 = 60,
            _60 = 61,
            _61 = 62,
            _62 = 63,
            _63 = 64,
        }
    }
}
