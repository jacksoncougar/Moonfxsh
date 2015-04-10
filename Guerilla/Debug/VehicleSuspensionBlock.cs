// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class VehicleSuspensionBlock : VehicleSuspensionBlockBase
    {
        public  VehicleSuspensionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class VehicleSuspensionBlockBase
    {
        internal Moonfish.Tags.StringID label;
        internal AnimationIndexStructBlock animation;
        internal Moonfish.Tags.StringID markerName;
        internal float massPointOffset;
        internal float fullExtensionGroundDepth;
        internal float fullCompressionGroundDepth;
        internal Moonfish.Tags.StringID regionName;
        internal float destroyedMassPointOffset;
        internal float destroyedFullExtensionGroundDepth;
        internal float destroyedFullCompressionGroundDepth;
        internal  VehicleSuspensionBlockBase(System.IO.BinaryReader binaryReader)
        {
            label = binaryReader.ReadStringID();
            animation = new AnimationIndexStructBlock(binaryReader);
            markerName = binaryReader.ReadStringID();
            massPointOffset = binaryReader.ReadSingle();
            fullExtensionGroundDepth = binaryReader.ReadSingle();
            fullCompressionGroundDepth = binaryReader.ReadSingle();
            regionName = binaryReader.ReadStringID();
            destroyedMassPointOffset = binaryReader.ReadSingle();
            destroyedFullExtensionGroundDepth = binaryReader.ReadSingle();
            destroyedFullCompressionGroundDepth = binaryReader.ReadSingle();
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
                binaryWriter.Write(label);
                animation.Write(binaryWriter);
                binaryWriter.Write(markerName);
                binaryWriter.Write(massPointOffset);
                binaryWriter.Write(fullExtensionGroundDepth);
                binaryWriter.Write(fullCompressionGroundDepth);
                binaryWriter.Write(regionName);
                binaryWriter.Write(destroyedMassPointOffset);
                binaryWriter.Write(destroyedFullExtensionGroundDepth);
                binaryWriter.Write(destroyedFullCompressionGroundDepth);
            }
        }
    };
}
