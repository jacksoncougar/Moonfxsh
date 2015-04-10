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
        public  ColonyBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ColonyBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.radius = binaryReader.ReadRange();
            this.invalidName_1 = binaryReader.ReadBytes(12);
            this.debugColor = binaryReader.ReadVector4();
            this.baseMap = binaryReader.ReadTagReference();
            this.detailMap = binaryReader.ReadTagReference();
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
            Unused = 1,
        };
    };
}
