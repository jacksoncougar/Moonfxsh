using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlatformSoundEffectFunctionBlock : PlatformSoundEffectFunctionBlockBase
    {
        public  PlatformSoundEffectFunctionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class PlatformSoundEffectFunctionBlockBase
    {
        internal Input input;
        internal Range range;
        internal MappingFunctionBlock function;
        internal float timePeriodSeconds;
        internal  PlatformSoundEffectFunctionBlockBase(BinaryReader binaryReader)
        {
            this.input = (Input)binaryReader.ReadInt16();
            this.range = (Range)binaryReader.ReadInt16();
            this.function = new MappingFunctionBlock(binaryReader);
            this.timePeriodSeconds = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal enum Input : short
        
        {
            Zero = 0,
            Time = 1,
            Scale = 2,
            Rolloff = 3,
        };
        internal enum Range : short
        
        {
            Zero = 0,
            Time = 1,
            Scale = 2,
            Rolloff = 3,
        };
    };
}
