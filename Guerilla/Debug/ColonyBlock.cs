// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("coln")]
    public  partial class ColonyBlock : ColonyBlockBase
    {
        public  ColonyBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 60)]
    public class ColonyBlockBase
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal Moonfish.Model.Range radius;
        internal byte[] invalidName_1;
        internal OpenTK.Vector4 debugColor;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference baseMap;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference detailMap;
        internal  ColonyBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(4);
            radius = binaryReader.ReadRange();
            invalidName_1 = binaryReader.ReadBytes(12);
            debugColor = binaryReader.ReadVector4();
            baseMap = binaryReader.ReadTagReference();
            detailMap = binaryReader.ReadTagReference();
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
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(radius);
                binaryWriter.Write(invalidName_1, 0, 12);
                binaryWriter.Write(debugColor);
                binaryWriter.Write(baseMap);
                binaryWriter.Write(detailMap);
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            Unused = 1,
        };
    };
}
