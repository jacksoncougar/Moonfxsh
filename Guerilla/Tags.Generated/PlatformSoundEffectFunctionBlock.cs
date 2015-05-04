// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlatformSoundEffectFunctionBlock : PlatformSoundEffectFunctionBlockBase
    {
        public PlatformSoundEffectFunctionBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class PlatformSoundEffectFunctionBlockBase : GuerillaBlock
    {
        internal Input input;
        internal Range range;
        internal MappingFunctionBlock function;
        internal float timePeriodSeconds;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public PlatformSoundEffectFunctionBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            input = (Input)binaryReader.ReadInt16();
            range = (Range)binaryReader.ReadInt16();
            function = new MappingFunctionBlock();
            blamPointers.Concat(function.ReadFields(binaryReader));
            timePeriodSeconds = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            function.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)input);
                binaryWriter.Write((Int16)range);
                function.Write(binaryWriter);
                binaryWriter.Write(timePeriodSeconds);
                return nextAddress;
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
