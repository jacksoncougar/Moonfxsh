// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioCutsceneTitleBlock : ScenarioCutsceneTitleBlockBase
    {
        public  ScenarioCutsceneTitleBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class ScenarioCutsceneTitleBlockBase
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
        internal  ScenarioCutsceneTitleBlockBase(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
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
