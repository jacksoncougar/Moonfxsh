// ReSharper disable All
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
        public  GrenadesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  GrenadesBlockBase(System.IO.BinaryReader binaryReader)
        {
            maximumCount = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            throwingEffect = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadBytes(16);
            equipment = binaryReader.ReadTagReference();
            projectile = binaryReader.ReadTagReference();
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
                binaryWriter.Write(maximumCount);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(throwingEffect);
                binaryWriter.Write(invalidName_0, 0, 16);
                binaryWriter.Write(equipment);
                binaryWriter.Write(projectile);
            }
        }
    };
}
