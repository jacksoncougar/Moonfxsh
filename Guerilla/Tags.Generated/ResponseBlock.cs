// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ResponseBlock : ResponseBlockBase
    {
        public  ResponseBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ResponseBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class ResponseBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent vocalizationName;
        internal Flags flags;
        internal short vocalizationIndexPostProcess;
        internal ResponseType responseType;
        internal short dialogueIndexImport;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ResponseBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            vocalizationName = binaryReader.ReadStringID();
            flags = (Flags)binaryReader.ReadInt16();
            vocalizationIndexPostProcess = binaryReader.ReadInt16();
            responseType = (ResponseType)binaryReader.ReadInt16();
            dialogueIndexImport = binaryReader.ReadInt16();
        }
        public  ResponseBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            vocalizationName = binaryReader.ReadStringID();
            flags = (Flags)binaryReader.ReadInt16();
            vocalizationIndexPostProcess = binaryReader.ReadInt16();
            responseType = (ResponseType)binaryReader.ReadInt16();
            dialogueIndexImport = binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(vocalizationName);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(vocalizationIndexPostProcess);
                binaryWriter.Write((Int16)responseType);
                binaryWriter.Write(dialogueIndexImport);
                return nextAddress;
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
