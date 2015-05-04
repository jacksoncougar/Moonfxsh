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
    public partial class PlatformSoundEffectTemplateComponentBlock : PlatformSoundEffectTemplateComponentBlockBase
    {
        public PlatformSoundEffectTemplateComponentBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class PlatformSoundEffectTemplateComponentBlockBase : GuerillaBlock
    {
        internal ValueType valueType;
        internal float defaultValue;
        internal float minimumValue;
        internal float maximumValue;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public PlatformSoundEffectTemplateComponentBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            valueType = (ValueType)binaryReader.ReadInt32();
            defaultValue = binaryReader.ReadSingle();
            minimumValue = binaryReader.ReadSingle();
            maximumValue = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)valueType);
                binaryWriter.Write(defaultValue);
                binaryWriter.Write(minimumValue);
                binaryWriter.Write(maximumValue);
                return nextAddress;
            }
        }
        internal enum ValueType : int
        {
            Zero = 0,
            Time = 1,
            Scale = 2,
            Rolloff = 3,
        };
    };
}
