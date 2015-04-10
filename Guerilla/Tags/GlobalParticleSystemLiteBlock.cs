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
        public  GlobalParticleSystemLiteBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalParticleSystemLiteBlockBase(BinaryReader binaryReader)
        {
            this.sprites = binaryReader.ReadTagReference();
            this.viewBoxWidth = binaryReader.ReadSingle();
            this.viewBoxHeight = binaryReader.ReadSingle();
            this.viewBoxDepth = binaryReader.ReadSingle();
            this.exclusionRadius = binaryReader.ReadSingle();
            this.maxVelocity = binaryReader.ReadSingle();
            this.minMass = binaryReader.ReadSingle();
            this.maxMass = binaryReader.ReadSingle();
            this.minSize = binaryReader.ReadSingle();
            this.maxSize = binaryReader.ReadSingle();
            this.maximumNumberOfParticles = binaryReader.ReadInt32();
            this.initialVelocity = binaryReader.ReadVector3();
            this.bitmapAnimationSpeed = binaryReader.ReadSingle();
            this.geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            this.particleSystemData = ReadParticleSystemLiteDataBlockArray(binaryReader);
            this.type = (Type)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.mininumOpacity = binaryReader.ReadSingle();
            this.maxinumOpacity = binaryReader.ReadSingle();
            this.rainStreakScale = binaryReader.ReadSingle();
            this.rainLineWidth = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.invalidName_2 = binaryReader.ReadBytes(4);
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
        internal  virtual ParticleSystemLiteDataBlock[] ReadParticleSystemLiteDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticleSystemLiteDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticleSystemLiteDataBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleSystemLiteDataBlock(binaryReader);
                }
            }
            return array;
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
