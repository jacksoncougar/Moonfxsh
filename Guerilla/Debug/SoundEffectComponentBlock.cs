// ReSharper disable All
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
        public  SoundEffectComponentBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  SoundEffectComponentBlockBase(System.IO.BinaryReader binaryReader)
        {
            sound = binaryReader.ReadTagReference();
            gainDB = binaryReader.ReadSingle();
            flags = (Flags)binaryReader.ReadInt32();
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
                binaryWriter.Write(sound);
                binaryWriter.Write(gainDB);
                binaryWriter.Write((Int32)flags);
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
