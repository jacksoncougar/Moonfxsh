using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureLightmapLightingEnvironmentBlock : StructureLightmapLightingEnvironmentBlockBase
    {
        public  StructureLightmapLightingEnvironmentBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 220)]
    public class StructureLightmapLightingEnvironmentBlockBase
    {
        internal OpenTK.Vector3 samplePoint;
        internal RedCoefficients[] redCoefficients;
        internal GreenCoefficients[] greenCoefficients;
        internal BlueCoefficients[] blueCoefficients;
        internal OpenTK.Vector3 meanIncomingLightDirection;
        internal OpenTK.Vector3 incomingLightIntensity;
        internal int specularBitmapIndex;
        internal OpenTK.Vector3 rotationAxis;
        internal float rotationSpeed;
        internal OpenTK.Vector3 bumpDirection;
        internal Moonfish.Tags.ColorR8G8B8 colorTint;
        internal ProceduralOveride proceduralOveride;
        internal Flags flags;
        internal OpenTK.Vector3 proceduralParam0;
        internal OpenTK.Vector3 proceduralParam1Xyz;
        internal float proceduralParam1W;
        internal  StructureLightmapLightingEnvironmentBlockBase(BinaryReader binaryReader)
        {
            this.samplePoint = binaryReader.ReadVector3();
            this.redCoefficients = new []{ new RedCoefficients(binaryReader), new RedCoefficients(binaryReader), new RedCoefficients(binaryReader), new RedCoefficients(binaryReader), new RedCoefficients(binaryReader), new RedCoefficients(binaryReader), new RedCoefficients(binaryReader), new RedCoefficients(binaryReader), new RedCoefficients(binaryReader),  };
            this.greenCoefficients = new []{ new GreenCoefficients(binaryReader), new GreenCoefficients(binaryReader), new GreenCoefficients(binaryReader), new GreenCoefficients(binaryReader), new GreenCoefficients(binaryReader), new GreenCoefficients(binaryReader), new GreenCoefficients(binaryReader), new GreenCoefficients(binaryReader), new GreenCoefficients(binaryReader),  };
            this.blueCoefficients = new []{ new BlueCoefficients(binaryReader), new BlueCoefficients(binaryReader), new BlueCoefficients(binaryReader), new BlueCoefficients(binaryReader), new BlueCoefficients(binaryReader), new BlueCoefficients(binaryReader), new BlueCoefficients(binaryReader), new BlueCoefficients(binaryReader), new BlueCoefficients(binaryReader),  };
            this.meanIncomingLightDirection = binaryReader.ReadVector3();
            this.incomingLightIntensity = binaryReader.ReadVector3();
            this.specularBitmapIndex = binaryReader.ReadInt32();
            this.rotationAxis = binaryReader.ReadVector3();
            this.rotationSpeed = binaryReader.ReadSingle();
            this.bumpDirection = binaryReader.ReadVector3();
            this.colorTint = binaryReader.ReadColorR8G8B8();
            this.proceduralOveride = (ProceduralOveride)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.proceduralParam0 = binaryReader.ReadVector3();
            this.proceduralParam1Xyz = binaryReader.ReadVector3();
            this.proceduralParam1W = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal enum ProceduralOveride : short
        
        {
            NoOveride = 0,
            CIEClearSky = 1,
            CIEPartlyCloudy = 2,
            CIECloudy = 3,
            DirectionalLight = 4,
            ConeLight = 5,
            SphereLight = 6,
            HemisphereLight = 7,
        };
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            LeaveMeAlonePlease = 1,
        };
        public class RedCoefficients
        {
            internal float redCoefficient;
            internal  RedCoefficients(BinaryReader binaryReader)
            {
                this.redCoefficient = binaryReader.ReadSingle();
            }
            internal  virtual byte[] ReadData(BinaryReader binaryReader)
            {
                var blamPointer = binaryReader.ReadBlamPointer(1);
                var data = new byte[blamPointer.elementCount];
                if(blamPointer.elementCount > 0)
                {
                    using (binaryReader.BaseStream.Pin())
                    {
                        binaryReader.BaseStream.Position = blamPointer[0];
                        data = binaryReader.ReadBytes(blamPointer.elementCount);
                    }
                }
                return data;
            }
        };
        public class GreenCoefficients
        {
            internal float greenCoefficient;
            internal  GreenCoefficients(BinaryReader binaryReader)
            {
                this.greenCoefficient = binaryReader.ReadSingle();
            }
            internal  virtual byte[] ReadData(BinaryReader binaryReader)
            {
                var blamPointer = binaryReader.ReadBlamPointer(1);
                var data = new byte[blamPointer.elementCount];
                if(blamPointer.elementCount > 0)
                {
                    using (binaryReader.BaseStream.Pin())
                    {
                        binaryReader.BaseStream.Position = blamPointer[0];
                        data = binaryReader.ReadBytes(blamPointer.elementCount);
                    }
                }
                return data;
            }
        };
        public class BlueCoefficients
        {
            internal float blueCoefficient;
            internal  BlueCoefficients(BinaryReader binaryReader)
            {
                this.blueCoefficient = binaryReader.ReadSingle();
            }
            internal  virtual byte[] ReadData(BinaryReader binaryReader)
            {
                var blamPointer = binaryReader.ReadBlamPointer(1);
                var data = new byte[blamPointer.elementCount];
                if(blamPointer.elementCount > 0)
                {
                    using (binaryReader.BaseStream.Pin())
                    {
                        binaryReader.BaseStream.Position = blamPointer[0];
                        data = binaryReader.ReadBytes(blamPointer.elementCount);
                    }
                }
                return data;
            }
        };
    };
}
