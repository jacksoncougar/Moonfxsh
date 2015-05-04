// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DetailObjectTypeBlock : DetailObjectTypeBlockBase
    {
        public  DetailObjectTypeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  DetailObjectTypeBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 96, Alignment = 4)]
    public class DetailObjectTypeBlockBase : GuerillaBlock
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
        internal Moonfish.Tags.ColourR8G8B8 minimumColor01;
        internal Moonfish.Tags.ColourR8G8B8 maximumColor01;
        internal Moonfish.Tags.ColourA1R1G1B1 ambientColor0255;
        internal byte[] invalidName_2;
        
        public override int SerializedSize{get { return 96; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  DetailObjectTypeBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadString32();
            sequenceIndex015 = binaryReader.ReadByte();
            typeFlags = (TypeFlags)binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(2);
            colorOverrideFactor = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(8);
            nearFadeDistanceWorldUnits = binaryReader.ReadSingle();
            farFadeDistanceWorldUnits = binaryReader.ReadSingle();
            sizeWorldUnitsPerPixel = binaryReader.ReadSingle();
            invalidName_1 = binaryReader.ReadBytes(4);
            minimumColor01 = binaryReader.ReadColorR8G8B8();
            maximumColor01 = binaryReader.ReadColorR8G8B8();
            ambientColor0255 = binaryReader.ReadColourA1R1G1B1();
            invalidName_2 = binaryReader.ReadBytes(4);
        }
        public  DetailObjectTypeBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            sequenceIndex015 = binaryReader.ReadByte();
            typeFlags = (TypeFlags)binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(2);
            colorOverrideFactor = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(8);
            nearFadeDistanceWorldUnits = binaryReader.ReadSingle();
            farFadeDistanceWorldUnits = binaryReader.ReadSingle();
            sizeWorldUnitsPerPixel = binaryReader.ReadSingle();
            invalidName_1 = binaryReader.ReadBytes(4);
            minimumColor01 = binaryReader.ReadColorR8G8B8();
            maximumColor01 = binaryReader.ReadColorR8G8B8();
            ambientColor0255 = binaryReader.ReadColourA1R1G1B1();
            invalidName_2 = binaryReader.ReadBytes(4);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(sequenceIndex015);
                binaryWriter.Write((Byte)typeFlags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(colorOverrideFactor);
                binaryWriter.Write(invalidName_0, 0, 8);
                binaryWriter.Write(nearFadeDistanceWorldUnits);
                binaryWriter.Write(farFadeDistanceWorldUnits);
                binaryWriter.Write(sizeWorldUnitsPerPixel);
                binaryWriter.Write(invalidName_1, 0, 4);
                binaryWriter.Write(minimumColor01);
                binaryWriter.Write(maximumColor01);
                binaryWriter.Write(ambientColor0255);
                binaryWriter.Write(invalidName_2, 0, 4);
                return nextAddress;
            }
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
