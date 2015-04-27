// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundEffectComponentBlock : SoundEffectComponentBlockBase
    {
        public  SoundEffectComponentBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundEffectComponentBlock(): base()
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
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundEffectComponentBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            sound = binaryReader.ReadTagReference();
            gainDB = binaryReader.ReadSingle();
            flags = (Flags)binaryReader.ReadInt32();
        }
        public  SoundEffectComponentBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            sound = binaryReader.ReadTagReference();
            gainDB = binaryReader.ReadSingle();
            flags = (Flags)binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
