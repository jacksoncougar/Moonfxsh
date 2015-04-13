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
        public  PlatformSoundEffectFunctionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class PlatformSoundEffectFunctionBlockBase  : IGuerilla
    {
        internal Input input;
        internal Range range;
        internal MappingFunctionBlock function;
        internal float timePeriodSeconds;
        internal  PlatformSoundEffectFunctionBlockBase(BinaryReader binaryReader)
        {
            input = (Input)binaryReader.ReadInt16();
            range = (Range)binaryReader.ReadInt16();
            function = new MappingFunctionBlock(binaryReader);
            timePeriodSeconds = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)input);
                binaryWriter.Write((Int16)range);
                function.Write(binaryWriter);
                binaryWriter.Write(timePeriodSeconds);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
