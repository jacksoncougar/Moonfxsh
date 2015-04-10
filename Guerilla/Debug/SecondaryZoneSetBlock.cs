// ReSharper disable All
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
        public  SecondaryZoneSetBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  SecondaryZoneSetBlockBase(System.IO.BinaryReader binaryReader)
        {
            areaType = (AreaType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            zone = binaryReader.ReadShortBlockIndex1();
            area = binaryReader.ReadShortBlockIndex2();
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
                binaryWriter.Write((Int16)areaType);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(zone);
                binaryWriter.Write(area);
            }
        }
        internal enum AreaType : short
        
        {
            Deault = 0,
            Search = 1,
            Goal = 2,
        };
    };
}
