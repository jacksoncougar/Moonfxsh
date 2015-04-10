using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DetailObjectTypeBlock : DetailObjectTypeBlockBase
    {
        public  DetailObjectTypeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 96)]
    public class DetailObjectTypeBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal byte sequenceIndex015;
        internal TypeFlags typeFlags;
        internal byte[] invalidName_;
        /// <summary>
        /// Fraction of detail object color to use instead of the base map color in the environment:[0,1]
        /// </summary>
        internal float colorOverrideFactor;
        internal byte[] invalidName_0;
        internal float nearFadeDistanceWorldUnits;
        internal float farFadeDistanceWorldUnits;
        internal float sizeWorldUnitsPerPixel;
        internal byte[] invalidName_1;
        internal Moonfish.Tags.ColorR8G8B8 minimumColor01;
        internal Moonfish.Tags.ColorR8G8B8 maximumColor01;
        internal Moonfish.Tags.ColourA1R1G1B1 ambientColor0255;
        internal byte[] invalidName_2;
        internal  DetailObjectTypeBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.sequenceIndex015 = binaryReader.ReadByte();
            this.typeFlags = (TypeFlags)binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.colorOverrideFactor = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(8);
            this.nearFadeDistanceWorldUnits = binaryReader.ReadSingle();
            this.farFadeDistanceWorldUnits = binaryReader.ReadSingle();
            this.sizeWorldUnitsPerPixel = binaryReader.ReadSingle();
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.minimumColor01 = binaryReader.ReadColorR8G8B8();
            this.maximumColor01 = binaryReader.ReadColorR8G8B8();
            this.ambientColor0255 = binaryReader.ReadColourA1R1G1B1();
            this.invalidName_2 = binaryReader.ReadBytes(4);
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
        [FlagsAttribute]
        internal enum TypeFlags : byte
        
        {
            Unused = 1,
            Unused0 = 2,
            InterpolateColorInHSV = 4,
            MoreColors = 8,
        };
    };
}
