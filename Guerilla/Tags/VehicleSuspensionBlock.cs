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
        public  VehicleSuspensionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class VehicleSuspensionBlockBase  : IGuerilla
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
        internal  VehicleSuspensionBlockBase(BinaryReader binaryReader)
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
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
