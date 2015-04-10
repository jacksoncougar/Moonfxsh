// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PrtLodInfoBlock : PrtLodInfoBlockBase
    {
        public  PrtLodInfoBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class PrtLodInfoBlockBase
    {
        internal int clusterOffset;
        internal PrtSectionInfoBlock[] sectionInfo;
        internal  PrtLodInfoBlockBase(System.IO.BinaryReader binaryReader)
        {
            clusterOffset = binaryReader.ReadInt32();
            ReadPrtSectionInfoBlockArray(binaryReader);
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
        internal  virtual PrtSectionInfoBlock[] ReadPrtSectionInfoBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PrtSectionInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PrtSectionInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PrtSectionInfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePrtSectionInfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(clusterOffset);
                WritePrtSectionInfoBlockArray(binaryWriter);
            }
        }
    };
}
