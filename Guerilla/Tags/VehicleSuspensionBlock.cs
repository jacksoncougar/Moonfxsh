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
        internal  VehicleSuspensionBlockBase(BinaryReader binaryReader)
        {
            this.label = binaryReader.ReadStringID();
            this.animation = new AnimationIndexStructBlock(binaryReader);
            this.markerName = binaryReader.ReadStringID();
            this.massPointOffset = binaryReader.ReadSingle();
            this.fullExtensionGroundDepth = binaryReader.ReadSingle();
            this.fullCompressionGroundDepth = binaryReader.ReadSingle();
            this.regionName = binaryReader.ReadStringID();
            this.destroyedMassPointOffset = binaryReader.ReadSingle();
            this.destroyedFullExtensionGroundDepth = binaryReader.ReadSingle();
            this.destroyedFullCompressionGroundDepth = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
