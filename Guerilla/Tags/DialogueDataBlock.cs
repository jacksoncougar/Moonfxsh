// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DialogueDataBlock : DialogueDataBlockBase
    {
        public  DialogueDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class DialogueDataBlockBase  : IGuerilla
    {
        internal short startIndexPostprocess;
        internal short lengthPostprocess;
        internal  DialogueDataBlockBase(BinaryReader binaryReader)
        {
            startIndexPostprocess = binaryReader.ReadInt16();
            lengthPostprocess = binaryReader.ReadInt16();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(startIndexPostprocess);
                binaryWriter.Write(lengthPostprocess);
                return nextAddress;
            }
        }
    };
}
