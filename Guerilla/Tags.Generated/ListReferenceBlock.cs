// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ListReferenceBlock : ListReferenceBlockBase
    {
        public  ListReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ListReferenceBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal SkinIndex skinIndex;
        internal short numVisibleItems;
        internal Moonfish.Tags.Point bottomLeft;
        internal AnimationIndex animationIndex;
        internal short introAnimationDelayMilliseconds;
        internal STextValuePairReferenceBlockUNUSED[] uNUSED;
        
        public override int SerializedSize{get { return 24; }}
        
        internal  ListReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            skinIndex = (SkinIndex)binaryReader.ReadInt16();
            numVisibleItems = binaryReader.ReadInt16();
            bottomLeft = binaryReader.ReadPoint();
            animationIndex = (AnimationIndex)binaryReader.ReadInt16();
            introAnimationDelayMilliseconds = binaryReader.ReadInt16();
            uNUSED = Guerilla.ReadBlockArray<STextValuePairReferenceBlockUNUSED>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write((Int16)skinIndex);
                binaryWriter.Write(numVisibleItems);
                binaryWriter.Write(bottomLeft);
                binaryWriter.Write((Int16)animationIndex);
                binaryWriter.Write(introAnimationDelayMilliseconds);
                nextAddress = Guerilla.WriteBlockArray<STextValuePairReferenceBlockUNUSED>(binaryWriter, uNUSED, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            ListWraps = 1,
            Interactive = 2,
        };
        internal enum SkinIndex : short
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
        };
        internal enum AnimationIndex : short
        {
            NONE = 0,
            InvalidName00 = 1,
            InvalidName01 = 2,
            InvalidName02 = 3,
            InvalidName03 = 4,
            InvalidName04 = 5,
            InvalidName05 = 6,
            InvalidName06 = 7,
            InvalidName07 = 8,
            InvalidName08 = 9,
            InvalidName09 = 10,
            InvalidName10 = 11,
            InvalidName11 = 12,
            InvalidName12 = 13,
            InvalidName13 = 14,
            InvalidName14 = 15,
            InvalidName15 = 16,
            InvalidName16 = 17,
            InvalidName17 = 18,
            InvalidName18 = 19,
            InvalidName19 = 20,
            InvalidName20 = 21,
            InvalidName21 = 22,
            InvalidName22 = 23,
            InvalidName23 = 24,
            InvalidName24 = 25,
            InvalidName25 = 26,
            InvalidName26 = 27,
            InvalidName27 = 28,
            InvalidName28 = 29,
            InvalidName29 = 30,
            InvalidName30 = 31,
            InvalidName31 = 32,
            InvalidName32 = 33,
            InvalidName33 = 34,
            InvalidName34 = 35,
            InvalidName35 = 36,
            InvalidName36 = 37,
            InvalidName37 = 38,
            InvalidName38 = 39,
            InvalidName39 = 40,
            InvalidName40 = 41,
            InvalidName41 = 42,
            InvalidName42 = 43,
            InvalidName43 = 44,
            InvalidName44 = 45,
            InvalidName45 = 46,
            InvalidName46 = 47,
            InvalidName47 = 48,
            InvalidName48 = 49,
            InvalidName49 = 50,
            InvalidName50 = 51,
            InvalidName51 = 52,
            InvalidName52 = 53,
            InvalidName53 = 54,
            InvalidName54 = 55,
            InvalidName55 = 56,
            InvalidName56 = 57,
            InvalidName57 = 58,
            InvalidName58 = 59,
            InvalidName59 = 60,
            InvalidName60 = 61,
            InvalidName61 = 62,
            InvalidName62 = 63,
            InvalidName63 = 64,
        };
    };
}
