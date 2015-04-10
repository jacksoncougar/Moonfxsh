// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("effe")]
    public  partial class EffectBlock : EffectBlockBase
    {
        public  EffectBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48)]
    public class EffectBlockBase
    {
        internal Flags flags;
        internal Moonfish.Tags.ShortBlockIndex1 loopStartEvent;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal EffectLocationsBlock[] locations;
        internal EffectEventBlock[] events;
        [TagReference("lsnd")]
        internal Moonfish.Tags.TagReference loopingSound;
        internal Moonfish.Tags.ShortBlockIndex1 location;
        internal byte[] invalidName_1;
        internal float alwaysPlayDistance;
        internal float neverPlayDistance;
        internal  EffectBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            loopStartEvent = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(4);
            ReadEffectLocationsBlockArray(binaryReader);
            ReadEffectEventBlockArray(binaryReader);
            loopingSound = binaryReader.ReadTagReference();
            location = binaryReader.ReadShortBlockIndex1();
            invalidName_1 = binaryReader.ReadBytes(2);
            alwaysPlayDistance = binaryReader.ReadSingle();
            neverPlayDistance = binaryReader.ReadSingle();
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
        internal  virtual EffectLocationsBlock[] ReadEffectLocationsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EffectLocationsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EffectLocationsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new EffectLocationsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual EffectEventBlock[] ReadEffectEventBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EffectEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EffectEventBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new EffectEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteEffectLocationsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteEffectEventBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(loopStartEvent);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 4);
                WriteEffectLocationsBlockArray(binaryWriter);
                WriteEffectEventBlockArray(binaryWriter);
                binaryWriter.Write(loopingSound);
                binaryWriter.Write(location);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(alwaysPlayDistance);
                binaryWriter.Write(neverPlayDistance);
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            DeletedWhenAttachmentDeactivates = 1,
        };
    };
}
