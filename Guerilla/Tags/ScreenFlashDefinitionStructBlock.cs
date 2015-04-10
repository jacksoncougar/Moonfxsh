using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScreenFlashDefinitionStructBlock : ScreenFlashDefinitionStructBlockBase
    {
        public  ScreenFlashDefinitionStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class ScreenFlashDefinitionStructBlockBase
    {
        internal Type type;
        internal Priority priority;
        internal float durationSeconds;
        internal FadeFunction fadeFunction;
        internal byte[] invalidName_;
        internal float maximumIntensity01;
        internal OpenTK.Vector4 color;
        internal  ScreenFlashDefinitionStructBlockBase(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.priority = (Priority)binaryReader.ReadInt16();
            this.durationSeconds = binaryReader.ReadSingle();
            this.fadeFunction = (FadeFunction)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.maximumIntensity01 = binaryReader.ReadSingle();
            this.color = binaryReader.ReadVector4();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
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
