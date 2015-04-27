// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GrenadesBlock : GrenadesBlockBase
    {
        public  GrenadesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GrenadesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 44, Alignment = 4)]
    public class GrenadesBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 44; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GrenadesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            maximumCount = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            throwingEffect = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadBytes(16);
            equipment = binaryReader.ReadTagReference();
            projectile = binaryReader.ReadTagReference();
        }
        public  GrenadesBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            maximumCount = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            throwingEffect = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadBytes(16);
            equipment = binaryReader.ReadTagReference();
            projectile = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(maximumCount);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(throwingEffect);
                binaryWriter.Write(invalidName_0, 0, 16);
                binaryWriter.Write(equipment);
                binaryWriter.Write(projectile);
                return nextAddress;
            }
        }
    };
}
