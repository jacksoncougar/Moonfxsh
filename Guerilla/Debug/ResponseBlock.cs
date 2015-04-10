// ReSharper disable All
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
        public  ResponseBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ResponseBlockBase(System.IO.BinaryReader binaryReader)
        {
            vocalizationName = binaryReader.ReadStringID();
            flags = (Flags)binaryReader.ReadInt16();
            vocalizationIndexPostProcess = binaryReader.ReadInt16();
            responseType = (ResponseType)binaryReader.ReadInt16();
            dialogueIndexImport = binaryReader.ReadInt16();
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
                binaryWriter.Write(vocalizationName);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(vocalizationIndexPostProcess);
                binaryWriter.Write((Int16)responseType);
                binaryWriter.Write(dialogueIndexImport);
            }
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
