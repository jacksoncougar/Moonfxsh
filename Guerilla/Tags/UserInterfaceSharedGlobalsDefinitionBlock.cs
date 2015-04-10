using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("wigl")]
    public  partial class UserInterfaceSharedGlobalsDefinitionBlock : UserInterfaceSharedGlobalsDefinitionBlockBase
    {
        public  UserInterfaceSharedGlobalsDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 452)]
    public class UserInterfaceSharedGlobalsDefinitionBlockBase
    {
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal byte[] invalidName_3;
        internal byte[] invalidName_4;
        internal byte[] invalidName_5;
        internal byte[] invalidName_6;
        internal float overlayedScreenAlphaMod;
        internal short incTextUpdatePeriodMilliseconds;
        internal short incTextBlockCharacterASCIICode;
        internal float calloutTextScale;
        internal OpenTK.Vector4 progressBarColor;
        internal float nearClipPlaneDistanceObjectsCloserThanThisAreNotDrawn;
        internal float projectionPlaneDistanceDistanceAtWhichObjectsAreRenderedWhenZ0NormalSize;
        internal float farClipPlaneDistanceObjectsFartherThanThisAreNotDrawn;
        internal OpenTK.Vector4 overlayedInterfaceColor;
        internal byte[] invalidName_7;
        internal UiErrorCategoryBlock[] errors;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference soundTag;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference soundTag0;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference soundTag1;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference soundTag2;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference soundTag3;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference soundTag4;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference soundTag5;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference soundTag6;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference soundTag7;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference soundTag8;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference soundTag9;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference invalidName_8;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference soundTag10;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference invalidName_9;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference invalidName_10;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference invalidName_11;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference globalBitmapsTag;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference unicodeStringListTag;
        internal AnimationReferenceBlock[] screenAnimations;
        internal ShapeGroupReferenceBlock[] shapeGroups;
        internal PersistentBackgroundAnimationBlock[] animations;
        internal ListSkinReferenceBlock[] listItemSkins;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference buttonKeyTypeStrings;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference gameTypeStrings;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference invalidName_12;
        internal SkillToRankMappingBlock[] skillMappings;
        internal FullScreenHeaderTextFont fullScreenHeaderTextFont;
        internal LargeDialogHeaderTextFont largeDialogHeaderTextFont;
        internal HalfDialogHeaderTextFont halfDialogHeaderTextFont;
        internal QtrDialogHeaderTextFont qtrDialogHeaderTextFont;
        internal OpenTK.Vector4 defaultTextColor;
        internal OpenTK.Vector2 fullScreenHeaderTextBounds;
        internal OpenTK.Vector2 fullScreenButtonKeyTextBounds;
        internal OpenTK.Vector2 largeDialogHeaderTextBounds;
        internal OpenTK.Vector2 largeDialogButtonKeyTextBounds;
        internal OpenTK.Vector2 halfDialogHeaderTextBounds;
        internal OpenTK.Vector2 halfDialogButtonKeyTextBounds;
        internal OpenTK.Vector2 qtrDialogHeaderTextBounds;
        internal OpenTK.Vector2 qtrDialogButtonKeyTextBounds;
        [TagReference("lsnd")]
        internal Moonfish.Tags.TagReference mainMenuMusic;
        internal int musicFadeTimeMilliseconds;
        internal  UserInterfaceSharedGlobalsDefinitionBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(16);
            this.invalidName_2 = binaryReader.ReadBytes(8);
            this.invalidName_3 = binaryReader.ReadBytes(8);
            this.invalidName_4 = binaryReader.ReadBytes(16);
            this.invalidName_5 = binaryReader.ReadBytes(8);
            this.invalidName_6 = binaryReader.ReadBytes(8);
            this.overlayedScreenAlphaMod = binaryReader.ReadSingle();
            this.incTextUpdatePeriodMilliseconds = binaryReader.ReadInt16();
            this.incTextBlockCharacterASCIICode = binaryReader.ReadInt16();
            this.calloutTextScale = binaryReader.ReadSingle();
            this.progressBarColor = binaryReader.ReadVector4();
            this.nearClipPlaneDistanceObjectsCloserThanThisAreNotDrawn = binaryReader.ReadSingle();
            this.projectionPlaneDistanceDistanceAtWhichObjectsAreRenderedWhenZ0NormalSize = binaryReader.ReadSingle();
            this.farClipPlaneDistanceObjectsFartherThanThisAreNotDrawn = binaryReader.ReadSingle();
            this.overlayedInterfaceColor = binaryReader.ReadVector4();
            this.invalidName_7 = binaryReader.ReadBytes(12);
            this.errors = ReadUiErrorCategoryBlockArray(binaryReader);
            this.soundTag = binaryReader.ReadTagReference();
            this.soundTag0 = binaryReader.ReadTagReference();
            this.soundTag1 = binaryReader.ReadTagReference();
            this.soundTag2 = binaryReader.ReadTagReference();
            this.soundTag3 = binaryReader.ReadTagReference();
            this.soundTag4 = binaryReader.ReadTagReference();
            this.soundTag5 = binaryReader.ReadTagReference();
            this.soundTag6 = binaryReader.ReadTagReference();
            this.soundTag7 = binaryReader.ReadTagReference();
            this.soundTag8 = binaryReader.ReadTagReference();
            this.soundTag9 = binaryReader.ReadTagReference();
            this.invalidName_8 = binaryReader.ReadTagReference();
            this.soundTag10 = binaryReader.ReadTagReference();
            this.invalidName_9 = binaryReader.ReadTagReference();
            this.invalidName_10 = binaryReader.ReadTagReference();
            this.invalidName_11 = binaryReader.ReadTagReference();
            this.globalBitmapsTag = binaryReader.ReadTagReference();
            this.unicodeStringListTag = binaryReader.ReadTagReference();
            this.screenAnimations = ReadAnimationReferenceBlockArray(binaryReader);
            this.shapeGroups = ReadShapeGroupReferenceBlockArray(binaryReader);
            this.animations = ReadPersistentBackgroundAnimationBlockArray(binaryReader);
            this.listItemSkins = ReadListSkinReferenceBlockArray(binaryReader);
            this.buttonKeyTypeStrings = binaryReader.ReadTagReference();
            this.gameTypeStrings = binaryReader.ReadTagReference();
            this.invalidName_12 = binaryReader.ReadTagReference();
            this.skillMappings = ReadSkillToRankMappingBlockArray(binaryReader);
            this.fullScreenHeaderTextFont = (FullScreenHeaderTextFont)binaryReader.ReadInt16();
            this.largeDialogHeaderTextFont = (LargeDialogHeaderTextFont)binaryReader.ReadInt16();
            this.halfDialogHeaderTextFont = (HalfDialogHeaderTextFont)binaryReader.ReadInt16();
            this.qtrDialogHeaderTextFont = (QtrDialogHeaderTextFont)binaryReader.ReadInt16();
            this.defaultTextColor = binaryReader.ReadVector4();
            this.fullScreenHeaderTextBounds = binaryReader.ReadVector2();
            this.fullScreenButtonKeyTextBounds = binaryReader.ReadVector2();
            this.largeDialogHeaderTextBounds = binaryReader.ReadVector2();
            this.largeDialogButtonKeyTextBounds = binaryReader.ReadVector2();
            this.halfDialogHeaderTextBounds = binaryReader.ReadVector2();
            this.halfDialogButtonKeyTextBounds = binaryReader.ReadVector2();
            this.qtrDialogHeaderTextBounds = binaryReader.ReadVector2();
            this.qtrDialogButtonKeyTextBounds = binaryReader.ReadVector2();
            this.mainMenuMusic = binaryReader.ReadTagReference();
            this.musicFadeTimeMilliseconds = binaryReader.ReadInt32();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual UiErrorCategoryBlock[] ReadUiErrorCategoryBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UiErrorCategoryBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UiErrorCategoryBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UiErrorCategoryBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AnimationReferenceBlock[] ReadAnimationReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShapeGroupReferenceBlock[] ReadShapeGroupReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShapeGroupReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShapeGroupReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShapeGroupReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PersistentBackgroundAnimationBlock[] ReadPersistentBackgroundAnimationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PersistentBackgroundAnimationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PersistentBackgroundAnimationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PersistentBackgroundAnimationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ListSkinReferenceBlock[] ReadListSkinReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ListSkinReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ListSkinReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ListSkinReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SkillToRankMappingBlock[] ReadSkillToRankMappingBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SkillToRankMappingBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SkillToRankMappingBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SkillToRankMappingBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum FullScreenHeaderTextFont : short
        
        {
            Terminal = 0,
            BodyText = 1,
            Title = 2,
            SuperLargeFont = 3,
            LargeBodyText = 4,
            SplitScreenHudMessage = 5,
            FullScreenHudMessage = 6,
            EnglishBodyText = 7,
            HUDNumberText = 8,
            SubtitleFont = 9,
            MainMenuFont = 10,
            TextChatFont = 11,
        };
        internal enum LargeDialogHeaderTextFont : short
        
        {
            Terminal = 0,
            BodyText = 1,
            Title = 2,
            SuperLargeFont = 3,
            LargeBodyText = 4,
            SplitScreenHudMessage = 5,
            FullScreenHudMessage = 6,
            EnglishBodyText = 7,
            HUDNumberText = 8,
            SubtitleFont = 9,
            MainMenuFont = 10,
            TextChatFont = 11,
        };
        internal enum HalfDialogHeaderTextFont : short
        
        {
            Terminal = 0,
            BodyText = 1,
            Title = 2,
            SuperLargeFont = 3,
            LargeBodyText = 4,
            SplitScreenHudMessage = 5,
            FullScreenHudMessage = 6,
            EnglishBodyText = 7,
            HUDNumberText = 8,
            SubtitleFont = 9,
            MainMenuFont = 10,
            TextChatFont = 11,
        };
        internal enum QtrDialogHeaderTextFont : short
        
        {
            Terminal = 0,
            BodyText = 1,
            Title = 2,
            SuperLargeFont = 3,
            LargeBodyText = 4,
            SplitScreenHudMessage = 5,
            FullScreenHudMessage = 6,
            EnglishBodyText = 7,
            HUDNumberText = 8,
            SubtitleFont = 9,
            MainMenuFont = 10,
            TextChatFont = 11,
        };
    };
}
