// ReSharper disable All
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
        public  QuantizedOrientationStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  QuantizedOrientationStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            rotationX = binaryReader.ReadInt16();
            rotationY = binaryReader.ReadInt16();
            rotationZ = binaryReader.ReadInt16();
            rotationW = binaryReader.ReadInt16();
            defaultTranslation = binaryReader.ReadVector3();
            defaultScale = binaryReader.ReadSingle();
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
                binaryWriter.Write(rotationX);
                binaryWriter.Write(rotationY);
                binaryWriter.Write(rotationZ);
                binaryWriter.Write(rotationW);
                binaryWriter.Write(defaultTranslation);
                binaryWriter.Write(defaultScale);
            }
        }
    };
}
