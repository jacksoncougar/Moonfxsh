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
        public  AdditionalNodeDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 60, Alignment = 4)]
    public class AdditionalNodeDataBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID nodeName;
        internal OpenTK.Quaternion defaultRotation;
        internal OpenTK.Vector3 defaultTranslation;
        internal float defaultScale;
        internal OpenTK.Vector3 minBounds;
        internal OpenTK.Vector3 maxBounds;
        internal  AdditionalNodeDataBlockBase(BinaryReader binaryReader)
        {
            nodeName = binaryReader.ReadStringID();
            defaultRotation = binaryReader.ReadQuaternion();
            defaultTranslation = binaryReader.ReadVector3();
            defaultScale = binaryReader.ReadSingle();
            minBounds = binaryReader.ReadVector3();
            maxBounds = binaryReader.ReadVector3();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(nodeName);
                binaryWriter.Write(defaultRotation);
                binaryWriter.Write(defaultTranslation);
                binaryWriter.Write(defaultScale);
                binaryWriter.Write(minBounds);
                binaryWriter.Write(maxBounds);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
