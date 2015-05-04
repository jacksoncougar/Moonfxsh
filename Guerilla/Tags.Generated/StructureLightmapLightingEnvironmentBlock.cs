// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureLightmapLightingEnvironmentBlock : StructureLightmapLightingEnvironmentBlockBase
    {
        public StructureLightmapLightingEnvironmentBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 220, Alignment = 4)]
    public class StructureLightmapLightingEnvironmentBlockBase : GuerillaBlock
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
        internal Moonfish.Tags.ColourR8G8B8 colorTint;
        internal ProceduralOveride proceduralOveride;
        internal Flags flags;
        internal OpenTK.Vector3 proceduralParam0;
        internal OpenTK.Vector3 proceduralParam1Xyz;
        internal float proceduralParam1W;
        public override int SerializedSize { get { return 220; } }
        public override int Alignment { get { return 4; } }
        public StructureLightmapLightingEnvironmentBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            samplePoint = binaryReader.ReadVector3();
            redCoefficients = new []{ new RedCoefficients(), new RedCoefficients(), new RedCoefficients(), new RedCoefficients(), new RedCoefficients(), new RedCoefficients(), new RedCoefficients(), new RedCoefficients(), new RedCoefficients() };
            blamPointers.Concat(redCoefficients[0].ReadFields(binaryReader));
            blamPointers.Concat(redCoefficients[1].ReadFields(binaryReader));
            blamPointers.Concat(redCoefficients[2].ReadFields(binaryReader));
            blamPointers.Concat(redCoefficients[3].ReadFields(binaryReader));
            blamPointers.Concat(redCoefficients[4].ReadFields(binaryReader));
            blamPointers.Concat(redCoefficients[5].ReadFields(binaryReader));
            blamPointers.Concat(redCoefficients[6].ReadFields(binaryReader));
            blamPointers.Concat(redCoefficients[7].ReadFields(binaryReader));
            blamPointers.Concat(redCoefficients[8].ReadFields(binaryReader));
            greenCoefficients = new []{ new GreenCoefficients(), new GreenCoefficients(), new GreenCoefficients(), new GreenCoefficients(), new GreenCoefficients(), new GreenCoefficients(), new GreenCoefficients(), new GreenCoefficients(), new GreenCoefficients() };
            blamPointers.Concat(greenCoefficients[0].ReadFields(binaryReader));
            blamPointers.Concat(greenCoefficients[1].ReadFields(binaryReader));
            blamPointers.Concat(greenCoefficients[2].ReadFields(binaryReader));
            blamPointers.Concat(greenCoefficients[3].ReadFields(binaryReader));
            blamPointers.Concat(greenCoefficients[4].ReadFields(binaryReader));
            blamPointers.Concat(greenCoefficients[5].ReadFields(binaryReader));
            blamPointers.Concat(greenCoefficients[6].ReadFields(binaryReader));
            blamPointers.Concat(greenCoefficients[7].ReadFields(binaryReader));
            blamPointers.Concat(greenCoefficients[8].ReadFields(binaryReader));
            blueCoefficients = new []{ new BlueCoefficients(), new BlueCoefficients(), new BlueCoefficients(), new BlueCoefficients(), new BlueCoefficients(), new BlueCoefficients(), new BlueCoefficients(), new BlueCoefficients(), new BlueCoefficients() };
            blamPointers.Concat(blueCoefficients[0].ReadFields(binaryReader));
            blamPointers.Concat(blueCoefficients[1].ReadFields(binaryReader));
            blamPointers.Concat(blueCoefficients[2].ReadFields(binaryReader));
            blamPointers.Concat(blueCoefficients[3].ReadFields(binaryReader));
            blamPointers.Concat(blueCoefficients[4].ReadFields(binaryReader));
            blamPointers.Concat(blueCoefficients[5].ReadFields(binaryReader));
            blamPointers.Concat(blueCoefficients[6].ReadFields(binaryReader));
            blamPointers.Concat(blueCoefficients[7].ReadFields(binaryReader));
            blamPointers.Concat(blueCoefficients[8].ReadFields(binaryReader));
            meanIncomingLightDirection = binaryReader.ReadVector3();
            incomingLightIntensity = binaryReader.ReadVector3();
            specularBitmapIndex = binaryReader.ReadInt32();
            rotationAxis = binaryReader.ReadVector3();
            rotationSpeed = binaryReader.ReadSingle();
            bumpDirection = binaryReader.ReadVector3();
            colorTint = binaryReader.ReadColorR8G8B8();
            proceduralOveride = (ProceduralOveride)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            proceduralParam0 = binaryReader.ReadVector3();
            proceduralParam1Xyz = binaryReader.ReadVector3();
            proceduralParam1W = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            redCoefficients = ReadBlockArrayData<RedCoefficients>(binaryReader, blamPointers.Dequeue());
            greenCoefficients = ReadBlockArrayData<GreenCoefficients>(binaryReader, blamPointers.Dequeue());
            blueCoefficients = ReadBlockArrayData<BlueCoefficients>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(samplePoint);
                redCoefficients[0].Write(binaryWriter);
                redCoefficients[1].Write(binaryWriter);
                redCoefficients[2].Write(binaryWriter);
                redCoefficients[3].Write(binaryWriter);
                redCoefficients[4].Write(binaryWriter);
                redCoefficients[5].Write(binaryWriter);
                redCoefficients[6].Write(binaryWriter);
                redCoefficients[7].Write(binaryWriter);
                redCoefficients[8].Write(binaryWriter);
                greenCoefficients[0].Write(binaryWriter);
                greenCoefficients[1].Write(binaryWriter);
                greenCoefficients[2].Write(binaryWriter);
                greenCoefficients[3].Write(binaryWriter);
                greenCoefficients[4].Write(binaryWriter);
                greenCoefficients[5].Write(binaryWriter);
                greenCoefficients[6].Write(binaryWriter);
                greenCoefficients[7].Write(binaryWriter);
                greenCoefficients[8].Write(binaryWriter);
                blueCoefficients[0].Write(binaryWriter);
                blueCoefficients[1].Write(binaryWriter);
                blueCoefficients[2].Write(binaryWriter);
                blueCoefficients[3].Write(binaryWriter);
                blueCoefficients[4].Write(binaryWriter);
                blueCoefficients[5].Write(binaryWriter);
                blueCoefficients[6].Write(binaryWriter);
                blueCoefficients[7].Write(binaryWriter);
                blueCoefficients[8].Write(binaryWriter);
                binaryWriter.Write(meanIncomingLightDirection);
                binaryWriter.Write(incomingLightIntensity);
                binaryWriter.Write(specularBitmapIndex);
                binaryWriter.Write(rotationAxis);
                binaryWriter.Write(rotationSpeed);
                binaryWriter.Write(bumpDirection);
                binaryWriter.Write(colorTint);
                binaryWriter.Write((Int16)proceduralOveride);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(proceduralParam0);
                binaryWriter.Write(proceduralParam1Xyz);
                binaryWriter.Write(proceduralParam1W);
                return nextAddress;
            }
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
        [LayoutAttribute(Size = 4, Alignment = 1)]
        public class RedCoefficients : GuerillaBlock
        {
            internal float redCoefficient;
            public override int SerializedSize { get { return 4; } }
            public override int Alignment { get { return 1; } }
            public RedCoefficients() : base()
            {
            }
            public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
            {
                var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
                redCoefficient = binaryReader.ReadSingle();
                return blamPointers;
            }
            public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
            {
                base.ReadPointers(binaryReader, blamPointers);
            }
            public override int Write(BinaryWriter binaryWriter, int nextAddress)
            {
                base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(redCoefficient);
                    return nextAddress;
                }
            }
        };
        [LayoutAttribute(Size = 4, Alignment = 1)]
        public class GreenCoefficients : GuerillaBlock
        {
            internal float greenCoefficient;
            public override int SerializedSize { get { return 4; } }
            public override int Alignment { get { return 1; } }
            public GreenCoefficients() : base()
            {
            }
            public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
            {
                var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
                greenCoefficient = binaryReader.ReadSingle();
                return blamPointers;
            }
            public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
            {
                base.ReadPointers(binaryReader, blamPointers);
            }
            public override int Write(BinaryWriter binaryWriter, int nextAddress)
            {
                base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(greenCoefficient);
                    return nextAddress;
                }
            }
        };
        [LayoutAttribute(Size = 4, Alignment = 1)]
        public class BlueCoefficients : GuerillaBlock
        {
            internal float blueCoefficient;
            public override int SerializedSize { get { return 4; } }
            public override int Alignment { get { return 1; } }
            public BlueCoefficients() : base()
            {
            }
            public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
            {
                var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
                blueCoefficient = binaryReader.ReadSingle();
                return blamPointers;
            }
            public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
            {
                base.ReadPointers(binaryReader, blamPointers);
            }
            public override int Write(BinaryWriter binaryWriter, int nextAddress)
            {
                base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(blueCoefficient);
                    return nextAddress;
                }
            }
        };
    };
}
