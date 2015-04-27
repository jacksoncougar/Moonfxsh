// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioCutsceneTitleBlock : ScenarioCutsceneTitleBlockBase
    {
        public  ScenarioCutsceneTitleBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioCutsceneTitleBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class ScenarioCutsceneTitleBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal OpenTK.Vector2 textBoundsOnScreen;
        internal Justification justification;
        internal Font font;
        internal Moonfish.Tags.RGBColor textColor;
        internal Moonfish.Tags.RGBColor shadowColor;
        internal float fadeInTimeSeconds;
        internal float upTimeSeconds;
        internal float fadeOutTimeSeconds;
        internal byte[] padding;
        
        public override int SerializedSize{get { return 36; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioCutsceneTitleBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            textBoundsOnScreen = binaryReader.ReadVector2();
            justification = (Justification)binaryReader.ReadInt16();
            font = (Font)binaryReader.ReadInt16();
            textColor = binaryReader.ReadRGBColor();
            shadowColor = binaryReader.ReadRGBColor();
            fadeInTimeSeconds = binaryReader.ReadSingle();
            upTimeSeconds = binaryReader.ReadSingle();
            fadeOutTimeSeconds = binaryReader.ReadSingle();
            padding = binaryReader.ReadBytes(2);
        }
        public  ScenarioCutsceneTitleBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(textBoundsOnScreen);
                binaryWriter.Write((Int16)justification);
                binaryWriter.Write((Int16)font);
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
