using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundEffectComponentBlock : SoundEffectComponentBlockBase
    {
        public  SoundEffectComponentBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class SoundEffectComponentBlockBase
    {
        [TagReference("null")]
        internal Moonfish.Tags.TagReference sound;
        /// <summary>
        /// additional attenuation to sound
        /// </summary>
        internal float gainDB;
        internal Flags flags;
        internal  SoundEffectComponentBlockBase(BinaryReader binaryReader)
        {
            this.sound = binaryReader.ReadTagReference();
            this.gainDB = binaryReader.ReadSingle();
            this.flags = (Flags)binaryReader.ReadInt32();
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
