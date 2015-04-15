// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class OccluderToMachineDoorMapping : OccluderToMachineDoorMappingBase
    {
        public  OccluderToMachineDoorMapping(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 1, Alignment = 4)]
    public class OccluderToMachineDoorMappingBase  : IGuerilla
    {
        internal byte machineDoorIndex;
        internal  OccluderToMachineDoorMappingBase(BinaryReader binaryReader)
        {
            machineDoorIndex = binaryReader.ReadByte();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(machineDoorIndex);
                return nextAddress;
            }
        }
    };
}
