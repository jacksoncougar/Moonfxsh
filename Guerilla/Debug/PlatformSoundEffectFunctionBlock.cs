// ReSharper disable All
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
        public  PlatformSoundEffectFunctionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  PlatformSoundEffectFunctionBlockBase(System.IO.BinaryReader binaryReader)
        {
            input = (Input)binaryReader.ReadInt16();
            range = (Range)binaryReader.ReadInt16();
            function = new MappingFunctionBlock(binaryReader);
            timePeriodSeconds = binaryReader.ReadSingle();
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
                binaryWriter.Write((Int16)input);
                binaryWriter.Write((Int16)range);
                function.Write(binaryWriter);
                binaryWriter.Write(timePeriodSeconds);
            }
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
