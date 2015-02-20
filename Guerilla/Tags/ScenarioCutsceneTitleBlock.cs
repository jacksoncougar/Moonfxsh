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
        public  ScenarioCutsceneTitleBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioCutsceneTitleBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.textBoundsOnScreen = binaryReader.ReadVector2();
            this.justification = (Justification)binaryReader.ReadInt16();
            this.font = (Font)binaryReader.ReadInt16();
            this.textColor = binaryReader.ReadRGBColor();
            this.shadowColor = binaryReader.ReadRGBColor();
            this.fadeInTimeSeconds = binaryReader.ReadSingle();
            this.upTimeSeconds = binaryReader.ReadSingle();
            this.fadeOutTimeSeconds = binaryReader.ReadSingle();
            this.padding = binaryReader.ReadBytes(2);
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
