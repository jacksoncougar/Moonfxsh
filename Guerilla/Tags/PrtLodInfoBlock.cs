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
        public  PrtLodInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class PrtLodInfoBlockBase
    {
        internal int clusterOffset;
        internal PrtSectionInfoBlock[] sectionInfo;
        internal  PrtLodInfoBlockBase(BinaryReader binaryReader)
        {
            this.clusterOffset = binaryReader.ReadInt32();
            this.sectionInfo = ReadPrtSectionInfoBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal  virtual PrtSectionInfoBlock[] ReadPrtSectionInfoBlockArray(BinaryReader binaryReader)
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
    };
}
