// ReSharper disable All
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
        public  AdditionalNodeDataBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  AdditionalNodeDataBlockBase(System.IO.BinaryReader binaryReader)
        {
            nodeName = binaryReader.ReadStringID();
            defaultRotation = binaryReader.ReadQuaternion();
            defaultTranslation = binaryReader.ReadVector3();
            defaultScale = binaryReader.ReadSingle();
            minBounds = binaryReader.ReadVector3();
            maxBounds = binaryReader.ReadVector3();
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
                binaryWriter.Write(nodeName);
                binaryWriter.Write(defaultRotation);
                binaryWriter.Write(defaultTranslation);
                binaryWriter.Write(defaultScale);
                binaryWriter.Write(minBounds);
                binaryWriter.Write(maxBounds);
            }
        }
    };
}
