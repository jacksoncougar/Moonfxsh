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
        public  GlobalWindModelStructBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalWindModelStructBlockBase(BinaryReader binaryReader)
        {
            this.windTilingScale = binaryReader.ReadSingle();
            this.windPrimaryHeadingPitchStrength = binaryReader.ReadVector3();
            this.primaryRateOfChange = binaryReader.ReadSingle();
            this.primaryMinStrength = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.invalidName_1 = binaryReader.ReadBytes(12);
            this.windGustingHeadingPitchStrength = binaryReader.ReadVector3();
            this.gustDiretionalRateOfChange = binaryReader.ReadSingle();
            this.gustStrengthRateOfChange = binaryReader.ReadSingle();
            this.gustConeAngle = binaryReader.ReadSingle();
            this.invalidName_2 = binaryReader.ReadBytes(4);
            this.invalidName_3 = binaryReader.ReadBytes(4);
            this.invalidName_4 = binaryReader.ReadBytes(12);
            this.invalidName_5 = binaryReader.ReadBytes(12);
            this.invalidName_6 = binaryReader.ReadBytes(12);
            this.invalidName_7 = binaryReader.ReadBytes(12);
            this.turbulanceRateOfChange = binaryReader.ReadSingle();
            this.turbulenceScaleXYZ = binaryReader.ReadVector3();
            this.gravityConstant = binaryReader.ReadSingle();
            this.windPirmitives = ReadGloalWindPrimitivesBlockArray(binaryReader);
            this.invalidName_8 = binaryReader.ReadBytes(4);
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
        internal  virtual GloalWindPrimitivesBlock[] ReadGloalWindPrimitivesBlockArray(BinaryReader binaryReader)
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
    };
}
