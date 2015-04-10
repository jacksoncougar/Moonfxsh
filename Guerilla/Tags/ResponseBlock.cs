using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ResponseBlock : ResponseBlockBase
    {
        public  ResponseBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class ResponseBlockBase
    {
        internal Moonfish.Tags.StringID vocalizationName;
        internal Flags flags;
        internal short vocalizationIndexPostProcess;
        internal ResponseType responseType;
        internal short dialogueIndexImport;
        internal  ResponseBlockBase(BinaryReader binaryReader)
        {
            this.vocalizationName = binaryReader.ReadStringID();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.vocalizationIndexPostProcess = binaryReader.ReadInt16();
            this.responseType = (ResponseType)binaryReader.ReadInt16();
            this.dialogueIndexImport = binaryReader.ReadInt16();
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
        internal enum Flags : short
        
        {
            Nonexclusive = 1,
            TriggerResponse = 2,
        };
        internal enum ResponseType : short
        
        {
            Friend = 0,
            Enemy = 1,
            Listener = 2,
            Joint = 3,
            Peer = 4,
        };
    };
}
