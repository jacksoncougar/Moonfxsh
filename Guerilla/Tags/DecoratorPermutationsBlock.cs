using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DecoratorPermutationsBlock : DecoratorPermutationsBlockBase
    {
        public  DecoratorPermutationsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 38)]
    public class DecoratorPermutationsBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal Moonfish.Tags.ByteBlockIndex1 shader;
        internal byte[] invalidName_;
        internal Flags flags;
        internal FadeDistance fadeDistance;
        internal byte index;
        internal byte distributionWeight;
        internal Moonfish.Model.Range scale;
        internal Moonfish.Tags.RGBColor tint1;
        internal Moonfish.Tags.RGBColor tint2;
        internal float baseMapTintPercentage;
        internal float lightmapTintPercentage;
        internal float windScale;
        internal  DecoratorPermutationsBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.shader = binaryReader.ReadByteBlockIndex1();
            this.invalidName_ = binaryReader.ReadBytes(3);
            this.flags = (Flags)binaryReader.ReadByte();
            this.fadeDistance = (FadeDistance)binaryReader.ReadByte();
            this.index = binaryReader.ReadByte();
            this.distributionWeight = binaryReader.ReadByte();
            this.scale = binaryReader.ReadRange();
            this.tint1 = binaryReader.ReadRGBColor();
            this.tint2 = binaryReader.ReadRGBColor();
            this.baseMapTintPercentage = binaryReader.ReadSingle();
            this.lightmapTintPercentage = binaryReader.ReadSingle();
            this.windScale = binaryReader.ReadSingle();
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
        [FlagsAttribute]
        internal enum Flags : byte
        
        {
            AlignToNormal = 1,
            OnlyOnGround = 2,
            Upright = 4,
        };
        internal enum FadeDistance : byte
        
        {
            Close = 0,
            Medium = 1,
            Far = 2,
        };
    };
}
