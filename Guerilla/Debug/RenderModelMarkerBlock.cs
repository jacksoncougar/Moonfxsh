// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RenderModelMarkerBlock : RenderModelMarkerBlockBase
    {
        public  RenderModelMarkerBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class RenderModelMarkerBlockBase
    {
        internal byte regionIndex;
        internal byte permutationIndex;
        internal byte nodeIndex;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 translation;
        internal OpenTK.Quaternion rotation;
        internal float scale;
        internal  RenderModelMarkerBlockBase(System.IO.BinaryReader binaryReader)
        {
            regionIndex = binaryReader.ReadByte();
            permutationIndex = binaryReader.ReadByte();
            nodeIndex = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(1);
            translation = binaryReader.ReadVector3();
            rotation = binaryReader.ReadQuaternion();
            scale = binaryReader.ReadSingle();
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
                binaryWriter.Write(regionIndex);
                binaryWriter.Write(permutationIndex);
                binaryWriter.Write(nodeIndex);
                binaryWriter.Write(invalidName_, 0, 1);
                binaryWriter.Write(translation);
                binaryWriter.Write(rotation);
                binaryWriter.Write(scale);
            }
        }
    };
}
