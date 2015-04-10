using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class QuantizedOrientationStructBlock : QuantizedOrientationStructBlockBase
    {
        public  QuantizedOrientationStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class QuantizedOrientationStructBlockBase
    {
        internal short rotationX;
        internal short rotationY;
        internal short rotationZ;
        internal short rotationW;
        internal OpenTK.Vector3 defaultTranslation;
        internal float defaultScale;
        internal  QuantizedOrientationStructBlockBase(BinaryReader binaryReader)
        {
            this.rotationX = binaryReader.ReadInt16();
            this.rotationY = binaryReader.ReadInt16();
            this.rotationZ = binaryReader.ReadInt16();
            this.rotationW = binaryReader.ReadInt16();
            this.defaultTranslation = binaryReader.ReadVector3();
            this.defaultScale = binaryReader.ReadSingle();
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
    };
}
