// ReSharper disable All
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
        public  UserInterfaceSharedGlobalsDefinitionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  UserInterfaceSharedGlobalsDefinitionBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(16);
            invalidName_2 = binaryReader.ReadBytes(8);
            invalidName_3 = binaryReader.ReadBytes(8);
            invalidName_4 = binaryReader.ReadBytes(16);
            invalidName_5 = binaryReader.ReadBytes(8);
            invalidName_6 = binaryReader.ReadBytes(8);
            overlayedScreenAlphaMod = binaryReader.ReadSingle();
            incTextUpdatePeriodMilliseconds = binaryReader.ReadInt16();
            incTextBlockCharacterASCIICode = binaryReader.ReadInt16();
            calloutTextScale = binaryReader.ReadSingle();
            progressBarColor = binaryReader.ReadVector4();
            nearClipPlaneDistanceObjectsCloserThanThisAreNotDrawn = binaryReader.ReadSingle();
            projectionPlaneDistanceDistanceAtWhichObjectsAreRenderedWhenZ0NormalSize = binaryReader.ReadSingle();
            farClipPlaneDistanceObjectsFartherThanThisAreNotDrawn = binaryReader.ReadSingle();
            overlayedInterfaceColor = binaryReader.ReadVector4();
            invalidName_7 = binaryReader.ReadBytes(12);
            ReadUiErrorCategoryBlockArray(binaryReader);
            soundTag = binaryReader.ReadTagReference();
            soundTag0 = binaryReader.ReadTagReference();
            soundTag1 = binaryReader.ReadTagReference();
            soundTag2 = binaryReader.ReadTagReference();
            soundTag3 = binaryReader.ReadTagReference();
            soundTag4 = binaryReader.ReadTagReference();
            soundTag5 = binaryReader.ReadTagReference();
            soundTag6 = binaryReader.ReadTagReference();
            soundTag7 = binaryReader.ReadTagReference();
            soundTag8 = binaryReader.ReadTagReference();
            soundTag9 = binaryReader.ReadTagReference();
            invalidName_8 = binaryReader.ReadTagReference();
            soundTag10 = binaryReader.ReadTagReference();
            invalidName_9 = binaryReader.ReadTagReference();
            invalidName_10 = binaryReader.ReadTagReference();
            invalidName_11 = binaryReader.ReadTagReference();
            globalBitmapsTag = binaryReader.ReadTagReference();
            unicodeStringListTag = binaryReader.ReadTagReference();
            ReadAnimationReferenceBlockArray(binaryReader);
            ReadShapeGroupReferenceBlockArray(binaryReader);
            ReadPersistentBackgroundAnimationBlockArray(binaryReader);
            ReadListSkinReferenceBlockArray(binaryReader);
            buttonKeyTypeStrings = binaryReader.ReadTagReference();
            gameTypeStrings = binaryReader.ReadTagReference();
            invalidName_12 = binaryReader.ReadTagReference();
            ReadSkillToRankMappingBlockArray(binaryReader);
            fullScreenHeaderTextFont = (FullScreenHeaderTextFont)binaryReader.ReadInt16();
            largeDialogHeaderTextFont = (LargeDialogHeaderTextFont)binaryReader.ReadInt16();
            halfDialogHeaderTextFont = (HalfDialogHeaderTextFont)binaryReader.ReadInt16();
            qtrDialogHeaderTextFont = (QtrDialogHeaderTextFont)binaryReader.ReadInt16();
            defaultTextColor = binaryReader.ReadVector4();
            fullScreenHeaderTextBounds = binaryReader.ReadVector2();
            fullScreenButtonKeyTextBounds = binaryReader.ReadVector2();
            largeDialogHeaderTextBounds = binaryReader.ReadVector2();
            largeDialogButtonKeyTextBounds = binaryReader.ReadVector2();
            halfDialogHeaderTextBounds = binaryReader.ReadVector2();
            halfDialogButtonKeyTextBounds = binaryReader.ReadVector2();
            qtrDialogHeaderTextBounds = binaryReader.ReadVector2();
            qtrDialogButtonKeyTextBounds = binaryReader.ReadVector2();
            mainMenuMusic = binaryReader.ReadTagReference();
            musicFadeTimeMilliseconds = binaryReader.ReadInt32();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual UiErrorCategoryBlock[] ReadUiErrorCategoryBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual AnimationReferenceBlock[] ReadAnimationReferenceBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShapeGroupReferenceBlock[] ReadShapeGroupReferenceBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual PersistentBackgroundAnimationBlock[] ReadPersistentBackgroundAnimationBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ListSkinReferenceBlock[] ReadListSkinReferenceBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual SkillToRankMappingBlock[] ReadSkillToRankMappingBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteUiErrorCategoryBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAnimationReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShapeGroupReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePersistentBackgroundAnimationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteListSkinReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSkillToRankMappingBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 16);
                binaryWriter.Write(invalidName_2, 0, 8);
                binaryWriter.Write(invalidName_3, 0, 8);
                binaryWriter.Write(invalidName_4, 0, 16);
                binaryWriter.Write(invalidName_5, 0, 8);
                binaryWriter.Write(invalidName_6, 0, 8);
                binaryWriter.Write(overlayedScreenAlphaMod);
                binaryWriter.Write(incTextUpdatePeriodMilliseconds);
                binaryWriter.Write(incTextBlockCharacterASCIICode);
                binaryWriter.Write(calloutTextScale);
                binaryWriter.Write(progressBarColor);
                binaryWriter.Write(nearClipPlaneDistanceObjectsCloserThanThisAreNotDrawn);
                binaryWriter.Write(projectionPlaneDistanceDistanceAtWhichObjectsAreRenderedWhenZ0NormalSize);
                binaryWriter.Write(farClipPlaneDistanceObjectsFartherThanThisAreNotDrawn);
                binaryWriter.Write(overlayedInterfaceColor);
                binaryWriter.Write(invalidName_7, 0, 12);
                WriteUiErrorCategoryBlockArray(binaryWriter);
                binaryWriter.Write(soundTag);
                binaryWriter.Write(soundTag0);
                binaryWriter.Write(soundTag1);
                binaryWriter.Write(soundTag2);
                binaryWriter.Write(soundTag3);
                binaryWriter.Write(soundTag4);
                binaryWriter.Write(soundTag5);
                binaryWriter.Write(soundTag6);
                binaryWriter.Write(soundTag7);
                binaryWriter.Write(soundTag8);
                binaryWriter.Write(soundTag9);
                binaryWriter.Write(invalidName_8);
                binaryWriter.Write(soundTag10);
                binaryWriter.Write(invalidName_9);
                binaryWriter.Write(invalidName_10);
                binaryWriter.Write(invalidName_11);
                binaryWriter.Write(globalBitmapsTag);
                binaryWriter.Write(unicodeStringListTag);
                WriteAnimationReferenceBlockArray(binaryWriter);
                WriteShapeGroupReferenceBlockArray(binaryWriter);
                WritePersistentBackgroundAnimationBlockArray(binaryWriter);
                WriteListSkinReferenceBlockArray(binaryWriter);
                binaryWriter.Write(buttonKeyTypeStrings);
                binaryWriter.Write(gameTypeStrings);
                binaryWriter.Write(invalidName_12);
                WriteSkillToRankMappingBlockArray(binaryWriter);
                binaryWriter.Write((Int16)fullScreenHeaderTextFont);
                binaryWriter.Write((Int16)largeDialogHeaderTextFont);
                binaryWriter.Write((Int16)halfDialogHeaderTextFont);
                binaryWriter.Write((Int16)qtrDialogHeaderTextFont);
                binaryWriter.Write(defaultTextColor);
                binaryWriter.Write(fullScreenHeaderTextBounds);
                binaryWriter.Write(fullScreenButtonKeyTextBounds);
                binaryWriter.Write(largeDialogHeaderTextBounds);
                binaryWriter.Write(largeDialogButtonKeyTextBounds);
                binaryWriter.Write(halfDialogHeaderTextBounds);
                binaryWriter.Write(halfDialogButtonKeyTextBounds);
                binaryWriter.Write(qtrDialogHeaderTextBounds);
                binaryWriter.Write(qtrDialogButtonKeyTextBounds);
                binaryWriter.Write(mainMenuMusic);
                binaryWriter.Write(musicFadeTimeMilliseconds);
            }
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
