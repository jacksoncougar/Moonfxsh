// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalParticleSystemLiteBlock : GlobalParticleSystemLiteBlockBase
    {
        public  GlobalParticleSystemLiteBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 140)]
    public class GlobalParticleSystemLiteBlockBase
    {
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference sprites;
        internal float viewBoxWidth;
        internal float viewBoxHeight;
        internal float viewBoxDepth;
        internal float exclusionRadius;
        internal float maxVelocity;
        internal float minMass;
        internal float maxMass;
        internal float minSize;
        internal float maxSize;
        internal int maximumNumberOfParticles;
        internal OpenTK.Vector3 initialVelocity;
        internal float bitmapAnimationSpeed;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal ParticleSystemLiteDataBlock[] particleSystemData;
        internal Type type;
        internal byte[] invalidName_;
        internal float mininumOpacity;
        internal float maxinumOpacity;
        internal float rainStreakScale;
        internal float rainLineWidth;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal  GlobalParticleSystemLiteBlockBase(System.IO.BinaryReader binaryReader)
        {
            sprites = binaryReader.ReadTagReference();
            viewBoxWidth = binaryReader.ReadSingle();
            viewBoxHeight = binaryReader.ReadSingle();
            viewBoxDepth = binaryReader.ReadSingle();
            exclusionRadius = binaryReader.ReadSingle();
            maxVelocity = binaryReader.ReadSingle();
            minMass = binaryReader.ReadSingle();
            maxMass = binaryReader.ReadSingle();
            minSize = binaryReader.ReadSingle();
            maxSize = binaryReader.ReadSingle();
            maximumNumberOfParticles = binaryReader.ReadInt32();
            initialVelocity = binaryReader.ReadVector3();
            bitmapAnimationSpeed = binaryReader.ReadSingle();
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            ReadParticleSystemLiteDataBlockArray(binaryReader);
            type = (Type)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            mininumOpacity = binaryReader.ReadSingle();
            maxinumOpacity = binaryReader.ReadSingle();
            rainStreakScale = binaryReader.ReadSingle();
            rainLineWidth = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(4);
            invalidName_1 = binaryReader.ReadBytes(4);
            invalidName_2 = binaryReader.ReadBytes(4);
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
        internal  virtual ParticleSystemLiteDataBlock[] ReadParticleSystemLiteDataBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticleSystemLiteDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticleSystemLiteDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleSystemLiteDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteParticleSystemLiteDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(sprites);
                binaryWriter.Write(viewBoxWidth);
                binaryWriter.Write(viewBoxHeight);
                binaryWriter.Write(viewBoxDepth);
                binaryWriter.Write(exclusionRadius);
                binaryWriter.Write(maxVelocity);
                binaryWriter.Write(minMass);
                binaryWriter.Write(maxMass);
                binaryWriter.Write(minSize);
                binaryWriter.Write(maxSize);
                binaryWriter.Write(maximumNumberOfParticles);
                binaryWriter.Write(initialVelocity);
                binaryWriter.Write(bitmapAnimationSpeed);
                geometryBlockInfo.Write(binaryWriter);
                WriteParticleSystemLiteDataBlockArray(binaryWriter);
                binaryWriter.Write((Int16)type);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(mininumOpacity);
                binaryWriter.Write(maxinumOpacity);
                binaryWriter.Write(rainStreakScale);
                binaryWriter.Write(rainLineWidth);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(invalidName_1, 0, 4);
                binaryWriter.Write(invalidName_2, 0, 4);
            }
        }
        internal enum Type : short
        
        {
            Generic = 0,
            Snow = 1,
            Rain = 2,
            RainSplash = 3,
            Bugs = 4,
            SandStorm = 5,
            Debris = 6,
            Bubbles = 7,
        };
    };
}
