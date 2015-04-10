// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalWindModelStructBlock : GlobalWindModelStructBlockBase
    {
        public  GlobalWindModelStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 156)]
    public class GlobalWindModelStructBlockBase
    {
        internal float windTilingScale;
        internal OpenTK.Vector3 windPrimaryHeadingPitchStrength;
        internal float primaryRateOfChange;
        internal float primaryMinStrength;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal OpenTK.Vector3 windGustingHeadingPitchStrength;
        internal float gustDiretionalRateOfChange;
        internal float gustStrengthRateOfChange;
        internal float gustConeAngle;
        internal byte[] invalidName_2;
        internal byte[] invalidName_3;
        internal byte[] invalidName_4;
        internal byte[] invalidName_5;
        internal byte[] invalidName_6;
        internal byte[] invalidName_7;
        internal float turbulanceRateOfChange;
        internal OpenTK.Vector3 turbulenceScaleXYZ;
        internal float gravityConstant;
        internal GloalWindPrimitivesBlock[] windPirmitives;
        internal byte[] invalidName_8;
        internal  GlobalWindModelStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            windTilingScale = binaryReader.ReadSingle();
            windPrimaryHeadingPitchStrength = binaryReader.ReadVector3();
            primaryRateOfChange = binaryReader.ReadSingle();
            primaryMinStrength = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(4);
            invalidName_0 = binaryReader.ReadBytes(4);
            invalidName_1 = binaryReader.ReadBytes(12);
            windGustingHeadingPitchStrength = binaryReader.ReadVector3();
            gustDiretionalRateOfChange = binaryReader.ReadSingle();
            gustStrengthRateOfChange = binaryReader.ReadSingle();
            gustConeAngle = binaryReader.ReadSingle();
            invalidName_2 = binaryReader.ReadBytes(4);
            invalidName_3 = binaryReader.ReadBytes(4);
            invalidName_4 = binaryReader.ReadBytes(12);
            invalidName_5 = binaryReader.ReadBytes(12);
            invalidName_6 = binaryReader.ReadBytes(12);
            invalidName_7 = binaryReader.ReadBytes(12);
            turbulanceRateOfChange = binaryReader.ReadSingle();
            turbulenceScaleXYZ = binaryReader.ReadVector3();
            gravityConstant = binaryReader.ReadSingle();
            ReadGloalWindPrimitivesBlockArray(binaryReader);
            invalidName_8 = binaryReader.ReadBytes(4);
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
        internal  virtual GloalWindPrimitivesBlock[] ReadGloalWindPrimitivesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GloalWindPrimitivesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GloalWindPrimitivesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GloalWindPrimitivesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGloalWindPrimitivesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(windTilingScale);
                binaryWriter.Write(windPrimaryHeadingPitchStrength);
                binaryWriter.Write(primaryRateOfChange);
                binaryWriter.Write(primaryMinStrength);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(invalidName_1, 0, 12);
                binaryWriter.Write(windGustingHeadingPitchStrength);
                binaryWriter.Write(gustDiretionalRateOfChange);
                binaryWriter.Write(gustStrengthRateOfChange);
                binaryWriter.Write(gustConeAngle);
                binaryWriter.Write(invalidName_2, 0, 4);
                binaryWriter.Write(invalidName_3, 0, 4);
                binaryWriter.Write(invalidName_4, 0, 12);
                binaryWriter.Write(invalidName_5, 0, 12);
                binaryWriter.Write(invalidName_6, 0, 12);
                binaryWriter.Write(invalidName_7, 0, 12);
                binaryWriter.Write(turbulanceRateOfChange);
                binaryWriter.Write(turbulenceScaleXYZ);
                binaryWriter.Write(gravityConstant);
                WriteGloalWindPrimitivesBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_8, 0, 4);
            }
        }
    };
}
