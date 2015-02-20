using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SecondaryZoneSetBlock : SecondaryZoneSetBlockBase
    {
        public  SecondaryZoneSetBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class SecondaryZoneSetBlockBase
    {
        internal AreaType areaType;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ShortBlockIndex1 zone;
        internal Moonfish.Tags.ShortBlockIndex2 area;
        internal  SecondaryZoneSetBlockBase(BinaryReader binaryReader)
        {
            this.areaType = (AreaType)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.zone = binaryReader.ReadShortBlockIndex1();
            this.area = binaryReader.ReadShortBlockIndex2();
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
        internal enum AreaType : short
        
        {
            Deault = 0,
            Search = 1,
            Goal = 2,
        };
    };
}
