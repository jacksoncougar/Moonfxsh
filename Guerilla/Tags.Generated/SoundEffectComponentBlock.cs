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
    public partial class SoundEffectComponentBlock : SoundEffectComponentBlockBase
    {
        public SoundEffectComponentBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SoundEffectComponentBlockBase : GuerillaBlock
    {
        [TagReference("null")]
        internal Moonfish.Tags.TagReference sound;
        /// <summary>
        /// additional attenuation to sound
        /// </summary>
        internal float gainDB;
        internal Flags flags;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public SoundEffectComponentBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            sound = binaryReader.ReadTagReference();
            gainDB = binaryReader.ReadSingle();
            flags = (Flags)binaryReader.ReadInt32();
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
                binaryWriter.Write(sound);
                binaryWriter.Write(gainDB);
                binaryWriter.Write((Int32)flags);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            DontPlayAtStart = 1,
            PlayOnStop = 2,
            InvalidName = 4,
            PlayAlternate = 8,
            InvalidName0 = 16,
            SyncWithOriginLoopingSound = 32,
        };
    };
}
