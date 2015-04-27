// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScreenFlashDefinitionStructBlock : ScreenFlashDefinitionStructBlockBase
    {
        public  ScreenFlashDefinitionStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScreenFlashDefinitionStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class ScreenFlashDefinitionStructBlockBase : GuerillaBlock
    {
        internal Type type;
        internal Priority priority;
        internal float durationSeconds;
        internal FadeFunction fadeFunction;
        internal byte[] invalidName_;
        internal float maximumIntensity01;
        internal OpenTK.Vector4 color;
        
        public override int SerializedSize{get { return 32; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScreenFlashDefinitionStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            priority = (Priority)binaryReader.ReadInt16();
            durationSeconds = binaryReader.ReadSingle();
            fadeFunction = (FadeFunction)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            maximumIntensity01 = binaryReader.ReadSingle();
            color = binaryReader.ReadVector4();
        }
        public  ScreenFlashDefinitionStructBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
                binaryWriter.Write((Int16)priority);
                binaryWriter.Write(durationSeconds);
                binaryWriter.Write((Int16)fadeFunction);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(maximumIntensity01);
                binaryWriter.Write(color);
                return nextAddress;
            }
        }
        internal enum Type : short
        {
            None = 0,
            Lighten = 1,
            Darken = 2,
            Max = 3,
            Min = 4,
            Invert = 5,
            Tint = 6,
        };
        internal enum Priority : short
        {
            Low = 0,
            Medium = 1,
            High = 2,
        };
        internal enum FadeFunction : short
        {
            Linear = 0,
            Late = 1,
            VeryLate = 2,
            Early = 3,
            VeryEarly = 4,
            Cosine = 5,
            Zero = 6,
            One = 7,
        };
    };
}
