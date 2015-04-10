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
        public  EffectBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  EffectBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.loopStartEvent = binaryReader.ReadShortBlockIndex1();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.locations = ReadEffectLocationsBlockArray(binaryReader);
            this.events = ReadEffectEventBlockArray(binaryReader);
            this.loopingSound = binaryReader.ReadTagReference();
            this.location = binaryReader.ReadShortBlockIndex1();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.alwaysPlayDistance = binaryReader.ReadSingle();
            this.neverPlayDistance = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual EffectLocationsBlock[] ReadEffectLocationsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EffectLocationsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EffectLocationsBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new EffectLocationsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual EffectEventBlock[] ReadEffectEventBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EffectEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EffectEventBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new EffectEventBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            DeletedWhenAttachmentDeactivates = 1,
        };
    };
}
