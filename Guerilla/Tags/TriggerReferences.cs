using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class TriggerReferences : TriggerReferencesBase
    {
        public  TriggerReferences(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class TriggerReferencesBase
    {
        internal TriggerFlags triggerFlags;
        internal Moonfish.Tags.ShortBlockIndex1 trigger;
        internal byte[] invalidName_;
        internal  TriggerReferencesBase(BinaryReader binaryReader)
        {
            this.triggerFlags = (TriggerFlags)binaryReader.ReadInt32();
            this.trigger = binaryReader.ReadShortBlockIndex1();
            this.invalidName_ = binaryReader.ReadBytes(2);
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
        [FlagsAttribute]
        internal enum TriggerFlags : int
        
        {
            Not = 1,
        };
    };
}
