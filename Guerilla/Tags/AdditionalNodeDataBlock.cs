using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AdditionalNodeDataBlock : AdditionalNodeDataBlockBase
    {
        public  AdditionalNodeDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 60)]
    public class AdditionalNodeDataBlockBase
    {
        internal Moonfish.Tags.StringID nodeName;
        internal OpenTK.Quaternion defaultRotation;
        internal OpenTK.Vector3 defaultTranslation;
        internal float defaultScale;
        internal OpenTK.Vector3 minBounds;
        internal OpenTK.Vector3 maxBounds;
        internal  AdditionalNodeDataBlockBase(BinaryReader binaryReader)
        {
            this.nodeName = binaryReader.ReadStringID();
            this.defaultRotation = binaryReader.ReadQuaternion();
            this.defaultTranslation = binaryReader.ReadVector3();
            this.defaultScale = binaryReader.ReadSingle();
            this.minBounds = binaryReader.ReadVector3();
            this.maxBounds = binaryReader.ReadVector3();
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
