using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CollisionDamageBlock : CollisionDamageBlockBase
    {
        public  CollisionDamageBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 72)]
    public class CollisionDamageBlockBase
    {
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference collisionDamage;
        /// <summary>
        /// 0-oo
        /// </summary>
        internal float minGameAccDefault;
        /// <summary>
        /// 0-oo
        /// </summary>
        internal float maxGameAccDefault;
        /// <summary>
        /// 0-1
        /// </summary>
        internal float minGameScaleDefault;
        /// <summary>
        /// 0-1
        /// </summary>
        internal float maxGameScaleDefault;
        /// <summary>
        /// 0-oo
        /// </summary>
        internal float minAbsAccDefault;
        /// <summary>
        /// 0-oo
        /// </summary>
        internal float maxAbsAccDefault;
        /// <summary>
        /// 0-1
        /// </summary>
        internal float minAbsScaleDefault;
        /// <summary>
        /// 0-1
        /// </summary>
        internal float maxAbsScaleDefault;
        internal byte[] invalidName_;
        internal  CollisionDamageBlockBase(BinaryReader binaryReader)
        {
            this.collisionDamage = binaryReader.ReadTagReference();
            this.minGameAccDefault = binaryReader.ReadSingle();
            this.maxGameAccDefault = binaryReader.ReadSingle();
            this.minGameScaleDefault = binaryReader.ReadSingle();
            this.maxGameScaleDefault = binaryReader.ReadSingle();
            this.minAbsAccDefault = binaryReader.ReadSingle();
            this.maxAbsAccDefault = binaryReader.ReadSingle();
            this.minAbsScaleDefault = binaryReader.ReadSingle();
            this.maxAbsScaleDefault = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(32);
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
