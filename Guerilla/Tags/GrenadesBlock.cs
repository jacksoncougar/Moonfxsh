using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GrenadesBlock : GrenadesBlockBase
    {
        public  GrenadesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 44)]
    public class GrenadesBlockBase
    {
        internal short maximumCount;
        internal byte[] invalidName_;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference throwingEffect;
        internal byte[] invalidName_0;
        [TagReference("eqip")]
        internal Moonfish.Tags.TagReference equipment;
        [TagReference("proj")]
        internal Moonfish.Tags.TagReference projectile;
        internal  GrenadesBlockBase(BinaryReader binaryReader)
        {
            this.maximumCount = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.throwingEffect = binaryReader.ReadTagReference();
            this.invalidName_0 = binaryReader.ReadBytes(16);
            this.equipment = binaryReader.ReadTagReference();
            this.projectile = binaryReader.ReadTagReference();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
    };
}
