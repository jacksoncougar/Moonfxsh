// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioCutsceneTitleBlock : ScenarioCutsceneTitleBlockBase
    {
        public ScenarioCutsceneTitleBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class ScenarioCutsceneTitleBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal OpenTK.Vector2 textBoundsOnScreen;
        internal Justification justification;
        internal Font font;
        internal Moonfish.Tags.ColourR1G1B1 textColor;
        internal Moonfish.Tags.ColourR1G1B1 shadowColor;
        internal float fadeInTimeSeconds;
        internal float upTimeSeconds;
        internal float fadeOutTimeSeconds;
        internal byte[] padding;

        public override int SerializedSize
        {
            get { return 36; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioCutsceneTitleBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            textBoundsOnScreen = binaryReader.ReadVector2();
            justification = (Justification) binaryReader.ReadInt16();
            font = (Font) binaryReader.ReadInt16();
            textColor = binaryReader.ReadColourR1G1B1();
            shadowColor = binaryReader.ReadColourR1G1B1();
            fadeInTimeSeconds = binaryReader.ReadSingle();
            upTimeSeconds = binaryReader.ReadSingle();
            fadeOutTimeSeconds = binaryReader.ReadSingle();
            padding = binaryReader.ReadBytes(2);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(textBoundsOnScreen);
                binaryWriter.Write((Int16) justification);
                binaryWriter.Write((Int16) font);
                binaryWriter.Write(textColor);
                binaryWriter.Write(shadowColor);
                binaryWriter.Write(fadeInTimeSeconds);
                binaryWriter.Write(upTimeSeconds);
                binaryWriter.Write(fadeOutTimeSeconds);
                binaryWriter.Write(padding, 0, 2);
                return nextAddress;
            }
        }

        internal enum Justification : short
        {
            Left = 0,
            Right = 1,
            Center = 2,
            CustomTextEntry = 3,
        };

        internal enum Font : short
        {
            TerminalFont = 0,
            BodyTextFont = 1,
            TitleFont = 2,
            SuperLargeFont = 3,
            LargeBodyTextFont = 4,
            SplitScreenHudMessageFont = 5,
            FullScreenHudMessageFont = 6,
            EnglishBodyTextFont = 7,
            HudNumberFont = 8,
            SubtitleFont = 9,
            MainMenuFont = 10,
            TextChatFont = 11,
        };
    };
}